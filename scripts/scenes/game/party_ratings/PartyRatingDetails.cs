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
        PopupCentered();
        var partyManager = GetNode<party>("/root/PartyCS");
        Godot.Collections.Dictionary<string, string> ratings = partyManager.GetPartyRatings();
        string clubName = partyManager.GetClubNameByParty(partyId);
        string earnedMoney = ratings[partyId + "_money"];
        string earnedExp = ratings[partyId + "_exp"];
        string musicQuality = ratings[partyId + "_m_quality"];
        string musicQualityBoost = ratings[partyId + "_m_quality_boost"];
        string moneyBoost = ratings[partyId + "_money_boost"];
        string expBoost = ratings[partyId + "_exp_boost"];
        string wholeText = $"Detailed statistic and rating from party at {clubName}\n\n\n" +
                           $"Earned money: {earnedMoney}\n\n" +
                           $"Gained experience: {earnedExp}\n\n" +
                           $"Music quality: {musicQuality}\n\n\n" +
                           $"Money boost: {moneyBoost}\n\n" +
                           $"Experience boost: {expBoost}\n\n" +
                           $"Music quality boost: {musicQualityBoost}";

        GetNode<RichTextLabel>("DetailsText").Text = wholeText;
    }

}
