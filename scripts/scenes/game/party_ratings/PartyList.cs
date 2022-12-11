using Godot;
using System;

public class PartyList : ItemList
{
    
    public override void _Ready()
    {
        Connect("item_selected", this, "DisplayDetail");
    }

    /// <summary>
    /// Calls WindowDialog to popup and render details about given, by their id, rating
    /// </summary>
    /// <param name="id">Id of the rating</param>
    public void DisplayDetail(int id) {
        GetNode<PartyRatingDetails>("../Details").DisplayDetailedRating(id.ToString());
    }
}
