using System;
using Godot.Collections;
using Godot;

/// <summary>
/// This class controls Party Ratings menu including displaying and showing rating details
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

    private Godot.Collections.Dictionary<string, int> partyData = new Godot.Collections.Dictionary<string, int>();
    private Godot.Collections.Dictionary<string, string> partyRatings = new Godot.Collections.Dictionary<string, string>();
    
    public override void _Ready() {
        _itemList = GetNode<PartyList>("PartyList");
        this.Connect("about_to_show", this, "DisplayRatings");
        DisplayRatings();
    }

    /// <summary>
    /// Method to display ratings in the list
    /// </summary>
    public void DisplayRatings() {
        var partyManager = GetNode<party>("/root/PartyCS");
        string[] donePartys = partyManager.DonePartys as string[];
        partyData = partyManager.PartyData;
        partyRatings = partyManager.GetPartyRatings();
        
        Console.WriteLine($"All done partys: {donePartys}");
        ratingsList.Clear();
        foreach (var i  in donePartys) {
            Console.WriteLine($"Adding rating to the list:\n   _m_quality: {partyRatings[i.ToString() + "_m_quality"]}\n   i:{i}\n   clubId: {partyData[i.ToString() + "_club_id"]}");
            ratingsList.Add(i.ToString(), partyRatings[i.ToString() + "_m_quality"]);
            int clubId = partyData[i.ToString() + "_club_id"];
        }

        Console.WriteLine($"Displaying ratings... {ratingsList}");
        Console.WriteLine(ratingsList);
        _itemList.Clear();
        foreach (var rating in ratingsList) {
            string itemName = partyManager.GetClubNameByParty(rating.Key) + " - " + rating.Value;
            Console.WriteLine($"Adding rating: {itemName}");
            _itemList.AddItem(itemName);
        }
    }

    public void _on_PartyRatingsMenu_about_to_show() {
        DisplayRatings();
    }
}
