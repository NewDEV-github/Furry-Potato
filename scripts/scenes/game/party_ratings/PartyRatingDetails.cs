using Godot;
using System;

/// <summary>
/// Class used to display detailed information about rating
/// </summary>
public class PartyRatingDetails : WindowDialog
{

    /// <summary>
    /// This method displays detailed statistics about party (by given party id) from collected data
    /// </summary>
    /// <param name="partyId"></param>
    public void DisplayDetailedRating(string partyId) {
        PartyRatingsMenu prm = new PartyRatingsMenu();
        string clubName = prm.ratingsClubs[partyId];
        string earnedMoney = "";
        string earnedExp = "";
        string musicQuality = "";
        string musicQualityBoost = "";
        string moneyBoost = "";
        string expBoost = "";
        string wholeText = $"Detailed statistic and rating from party at {clubName}\n\n\n" +
                           $"Earned money: {earnedMoney}\n\n" +
                           $"Gained experience: {earnedExp}\n\n" +
                           $"Music quality{musicQuality}\n\n\n" +
                           $"Money boost: {moneyBoost}\n\n" +
                           $"Experience boost: {expBoost}\n\n" +
                           $"Music quality boost: {musicQualityBoost}";

    }

}
