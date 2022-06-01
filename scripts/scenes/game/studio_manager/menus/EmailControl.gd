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
	all_emails += 1
	email_list.append(title)
	email_titles[title] = title
	email_subjects[title] = subject
	email_texts[title] = text
	email_to[title] = to
	email_from[title] = from
	email_types[title] = email_type
	email_party_ids[title] = email_party_id
func _process(delta):
	if read_emails == all_emails:
		e_i.hide()
	elif read_emails < all_emails:
		e_i.show()
		
func _prerender_emails():
	for i in email_list:
		print("Adding email: " + email_titles[i])
		$VBoxContainer/EmailList.add_item(email_titles[i])




func check_emails():
	var current_experience = GameController.data['experience']
	print("Current experience is: " + str(current_experience))
	var all_partys = PartyController.party_ids
	var all_partys_data = PartyController.party_data
	for i in all_partys:
		print(i)
		print(all_partys_data[i + "_req_experience"])
		if current_experience == all_partys_data[i + "_req_experience"] or current_experience > all_partys_data[i + "_base_experience"]:
			print("Found party!")
			var club_id = all_partys_data[i+"_club_id"]
			var party_club = ClubController.club_data[str(club_id)+"_name"]
			addEmail("Party at: " + party_club, "Party is going on in " + party_club, "Hey, as I said, party is going on in " + party_club + "\n\nPrice is pretty, pretty nice, should I say to the club manager,\nthat You'll be DJ that night?", GameController.data["DJName"].to_lower() + "@furry.potato", "dos@furry.potato", "party_email")
	_prerender_emails()
func _on_EmailList_item_activated(index):
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
		$"../EmailPreview/VBoxContainer/GoPartyButton".show()
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
