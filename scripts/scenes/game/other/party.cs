using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

/// <summary>
/// PartyController singleton
/// </summary>
public class party : Node {
    
    /// <summary>
    /// PartyEnded signal. Emitted with parameters, when party has finished.
    /// </summary>
    [Signal]
    delegate void PartyEnded(int id, int money, int experience, int musicQuality);
    
    /// <summary>
    /// Holds string id of currently played party
    /// </summary>
    public string CurrentPartyId = "";
    
    /// <summary>
    /// List of all done partys
    /// </summary>
    public string[] DonePartys = new string[] { };
    
    /// <summary>
    /// List of all partys' id's
    /// </summary>
    public string[] PartyIds = { "0", "1", "2", "3", "4",};
    
    /// <summary>
    /// Contains data of all party ratings
    /// </summary>
    private readonly Godot.Collections.Dictionary<string, string> _partyRatings = new Godot.Collections.Dictionary<string, string>();
	
    /// <summary>
    /// Contains data of all of the partys
    /// </summary>
    public readonly Godot.Collections.Dictionary<string, int> PartyData = new Godot.Collections.Dictionary<string, int>() {
        ["0_club_id"] = 0,
        ["0_base_price"] = 1000,
        ["0_base_experience"] = 100,
        ["0_req_experience"] = 0,
	
        ["1_club_id"] = 1,
        ["1_base_price"] = 1000,
        ["1_base_experience"] = 150,
        ["1_req_experience"] = 10,
	
        ["2_club_id"] = 2,
        ["2_base_price"] = 1000,
        ["2_base_experience"] = 170,
        ["2_req_experience"] = 200,
	
        ["3_club_id"] = 3,
        ["3_base_price"] = 1000,
        ["3_base_experience"] = 120,
        ["3_req_experience"] = 300,
	
        ["4_club_id"] = 4,
        ["4_base_price"] = 100,
        ["4_base_experience"] = 400,
        ["4_req_experience"] = 450,
        
    };

    /// <summary>
    /// Starts party
    /// </summary>
    /// <param name="id">Party id</param>
    public void StartParty(string id) {
	    CurrentPartyId = id;
    }

    /// <summary>
    /// Calculates rewards for party
    /// </summary>
    /// <param name="id">Party id</param>
    /// <returns>Dictionary of calculated data</returns>
    Godot.Collections.Dictionary<string, float> ComputePartyRewards(string id) {
	    Console.WriteLine($"Party number {id}");
	    Console.WriteLine(PartyData.ToString());
	    var gameCCS = GetNode<GameControllerCS>("/root/GameController");
	    int defaultMoney = PartyData[id + "_base_price"];
	    int defaultExp = PartyData[id + "_base_experience"];
	    float moneyMulti = gameCCS.GetFloats()["party_money_earnings_multiplier"];
	    float expMulti = gameCCS.GetFloats()["party_experience_earnings_multiplier"];
	    float musicQualityMulti = gameCCS.GetFloats()["party_music_quality_multiplier"];
	    float computedMoney = defaultMoney;
	    float computedExp = defaultExp;

	    if (moneyMulti > 0) {
		    computedMoney = defaultMoney + (defaultMoney * moneyMulti);
	    }

	    if (expMulti > 0) {
		    computedExp = defaultExp + (defaultExp * expMulti);
	    }

	    Godot.Collections.Dictionary<string, float> returnData = new Godot.Collections.Dictionary<string, float>() {
		    ["money"] = computedMoney,
		    ["exp"] = computedExp,
		    ["music_quality"] = musicQualityMulti
	    };
	    return returnData;
    }

    /// <summary>
    /// Method ends party executing required callbacks
    /// </summary>
    /// <exception cref="ArgumentNullException">Null exception whether PartyRewards weren't computed properly</exception>
    void EndParty() {
	    var gameCCS = GetNode<GameControllerCS>("/root/GameController");
	    Godot.Collections.Dictionary<string, float> partyRewards = ComputePartyRewards(CurrentPartyId) ?? throw new ArgumentNullException("ComputePartyRewards(CurrentPartyId)");
	    EmitSignal("PartyEnded", CurrentPartyId, partyRewards["money"], partyRewards["exp"], partyRewards["music_quality"]);
	    AddPartyRating(CurrentPartyId, new Godot.Collections.Dictionary<string, string>() {
		    ["experience"] = partyRewards["exp"].ToString(),
		    ["money"] = partyRewards["money"].ToString(),
		    ["m_quality"] = partyRewards["music_quality"].ToString(),
		    ["exp_boost"] = gameCCS.GetFloats()["party_experience_earnings_multiplier"].ToString(),
		    ["money_boost"] = gameCCS.GetFloats()["party_money_earnings_multiplier"].ToString(),
		    ["m_quality_boost"] = gameCCS.GetFloats()["party_music_quality_multiplier"].ToString()
	    });
	    var myList = new List<string>();
		myList.Add(CurrentPartyId);
	    
		foreach (var doneParty in DonePartys) {
		    myList.Add(doneParty);
	    }

	    DonePartys = myList.ToArray();
    }

    /// <summary>
    /// Adds party rating to database
    /// </summary>
    /// <param name="partyId">Party id</param>
    /// <param name="ratingData">Rating data</param>
    void AddPartyRating(string partyId, Godot.Collections.Dictionary<string, string> ratingData) {
	    _partyRatings.Add(partyId, ratingData["m_quality"]);
	    _partyRatings.Add(partyId + "_exp", ratingData["experience"]);
	    _partyRatings.Add(partyId + "_money", ratingData["money"]);
	    _partyRatings.Add(partyId + "_m_quality", ratingData["m_quality"]);
	    _partyRatings.Add(partyId + "_exp_boost", ratingData["exp_boost"]);
	    _partyRatings.Add(partyId + "_money_boost", ratingData["money_boost"]);
	    _partyRatings.Add(partyId + "_m_quality_boost", ratingData["m_quality_boost"]);
    }

    /// <summary>
    /// Returns bool whether party has been played or not
    /// </summary>
    /// <param name="id">Party id</param>
    /// <returns>true or false</returns>
    public bool CheckIfPartyWasDone(string id) {
	    return DonePartys.Contains(id);
    }

    /// <summary>
    /// Returns ratings of all done partys
    /// </summary>
    /// <returns>Dictionary of rating data</returns>
    public Godot.Collections.Dictionary<string, string> GetPartyRatings() {
	    return _partyRatings;
    }

     
    /// <summary>
    /// Gives us club name by party id
    /// </summary>
    /// <param name="partyId">Id of the party</param>
    /// <returns>Club name</returns>
    /// @todo Make this really returning club name, not it's id
    public string GetClubNameByParty(string partyId) {
	    return PartyData[partyId + "_club_id"].ToString();
    }
}
