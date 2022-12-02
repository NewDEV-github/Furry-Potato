using System.Collections.Generic;
using Godot;

/// <summary>
/// This class controls Party Ratings menu including displaying and showing rating details
/// @todo Implement getting list of the clubs and assign them to party id's
/// @todo Implement getting list of ratings from each party and assign them to party id's
/// @todo Fix refreshing party lists each time window is about to be shown
/// </summary>
public class PartyRatingsMenu : WindowDialog {
    
    /// <summary>
    /// This dictionary stands for {party_id: rating}
    /// </summary>
    public Dictionary<string, string> ratingsList = new Dictionary<string, string>();

    /// <summary>
    /// This dictionary stands for {party_id: club}
    /// </summary>
    public Dictionary<string, string> ratingsClubs = new Dictionary<string, string>();

    /// <summary>
    /// Item list instance, used to display ratings list.
    /// </summary>
    private PartyList _itemList;
    
    public override void _Ready() {
        Control partyManager = GetNode<Control>("/root/PartyController");
        int[] donePartys = partyManager.Get("done_partys") as int[];
        Godot.Collections.Dictionary<string, int> partyData = (Godot.Collections.Dictionary<string, int>)partyManager.Get("party_data");
        Godot.Collections.Dictionary<string, string> partyRatings = (Godot.Collections.Dictionary<string, string>)partyManager.Get("party_ratings");
  
        foreach (var i  in donePartys) {
            ratingsList.Add(i.ToString(), partyRatings[i.ToString() + "_m_quality"]);
            int clubId = partyData[i.ToString() + "_club_id"];
        }
        
        _itemList = GetNode<PartyList>("PartyList");
        this.Connect("about_to_show", this, "DisplayRatings");
        DisplayRatings();
    }

    /// <summary>
    /// Method to display ratings in the list
    /// </summary>
    void DisplayRatings() {
        foreach (var rating in ratingsList) {
            string itemName = ratingsClubs[rating.Key] + " - " + rating.Value;
            _itemList.AddItem(itemName);
        }
    }
}
