extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
signal email_added(email_title)
var email_list = []
var email_titles = {}
var email_subjects = {}
var email_texts = {}
var email_to = {}
var email_from = {}
var email_types = {}
var email_party_ids = {}
var read_emails = 0
var all_emails = 0
var readed_emails = []
onready var e_i = $"../../../menu/EmailMenu/UnReadEmailIndicator"
# Called when the node enters the scene tree for the first time.
func addEmail(title:String, subject:String, text:String, to:String, from:String, email_type:String = "normal", email_party_id:String="0"):
	if not email_list.has(title):
		all_emails += 1
		email_list.append(title)
		email_titles[title] = title
		email_subjects[title] = subject
		email_texts[title] = text
		email_to[title] = to
		email_from[title] = from
		email_types[title] = email_type
		email_party_ids[title] = email_party_id
func removeEmail(title:String):
	all_emails -= 1
	email_list.remove(email_list.find(title))
	email_titles.erase(title)
	email_subjects.erase(title)
	email_texts.erase(title)
	email_to.erase(title)
	email_from.erase(title)
	email_types.erase(title)
	email_party_ids.erase(title)
func _process(delta):
	if read_emails == all_emails:
		e_i.hide()
	elif read_emails < all_emails:
		e_i.show()
		
func _prerender_emails():
	$VBoxContainer/EmailList.clear()
	for i in email_list:
		print("Adding email: " + email_titles[i])
		$VBoxContainer/EmailList.add_item(email_titles[i])




func check_emails():
	var current_experience = GameController.GetInts()["experience"]
	print("Current experience is: " + str(current_experience))
	var all_partys = PartyCS.PartyIds
	var all_partys_data = PartyCS.PartyData
	for i in all_partys:
		print("party id: " + i)
		print("minimum exp: " + str(all_partys_data[i + "_req_experience"]))
		if current_experience >= all_partys_data[i + "_req_experience"]:
			print("Found party!")
			var club_id = all_partys_data[i+"_club_id"]
			var party_club = ClubController.ClubData[str(club_id)+"_name"]
			if PartyController.check_if_party_was_done(i) == false:
				var p_email = str(GameController.GetStrings()["DJName"]).to_lower().replace(' ', '_')
				var p_domain = str(GameController.GetStrings()["PlayerEmailDomain"])
				addEmail("Party at: " + party_club, "Party is going on in " + party_club, "Hey, as I said, party is going on in " + party_club + "\n\nPrice is pretty, pretty nice, should I say to the club manager,\nthat You'll be DJ that night?", p_email + "@" + p_domain, "dos@furry.potato", "party_email", i)
	_prerender_emails()
func _on_EmailList_item_activated(index):
	$"../EmailPreview/VBoxContainer/GoPartyButton".disconnect("pressed", self, "_on_GoPartyButton_pressed")
	var tmp_party_id = ""
	var item_text = $VBoxContainer/EmailList.get_item_text(index)
	if not readed_emails.has(item_text):
		read_emails += 1
		readed_emails.append(item_text)
	if email_types[item_text] == "party_email":
		print("Oh fuck, party...")
		tmp_party_id = email_party_ids[item_text]
		print(tmp_party_id)
		print(email_party_ids[item_text])
		
		$"../EmailPreview/VBoxContainer/GoPartyButton".connect("pressed", self, "_on_GoPartyButton_pressed", [tmp_party_id])
		if PartyCS.CheckIfPartyWasDone(tmp_party_id) == false:
			$"../EmailPreview/VBoxContainer/GoPartyButton".show()
		else:
			$"../EmailPreview/VBoxContainer/GoPartyButton".hide()
			print("that party was done before")
	else:
		$"../EmailPreview/VBoxContainer/GoPartyButton".hide()
	$"../EmailPreview/VBoxContainer/EmailTitle".text = "Title: " + email_titles[item_text]
	$"../EmailPreview/VBoxContainer/EmailTo".text = "To: " + email_to[item_text]
	$"../EmailPreview/VBoxContainer/EmailFrom".text = "From: " + email_from[item_text]
	$"../EmailPreview/VBoxContainer/EmailSubject".text = "Subject: " + email_subjects[item_text]
	$"../EmailPreview/VBoxContainer/EmailText".text = email_texts[item_text]
	$"../EmailPreview".window_title = item_text
	$"../EmailPreview".popup_centered()


func _on_GoPartyButton_pressed(arg1):
	print("Going to party number:" + arg1)
	PartyController.start_party(str(arg1))
