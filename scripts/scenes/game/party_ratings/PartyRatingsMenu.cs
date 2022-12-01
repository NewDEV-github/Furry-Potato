using System.Collections.Generic;
using Godot;

/// <summary>
/// This class controls Party Ratings menu including displaying and showing rating details
/// @todo Implement getting list of the clubs and assign them to party id's
/// @todo Implement getting list of ratings from each party and assign them to party id's
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
        _itemList = GetNode<PartyList>("PartyList");
        this.Connect("about_to_show", this, "DisplayRatings");
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
