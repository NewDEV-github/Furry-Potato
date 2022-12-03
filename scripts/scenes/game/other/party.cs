using System;
using System.Linq;
using Godot;
using Godot.Collections;

/// <summary>
/// PartyController singleton
/// @todo needs GameController to be rewritten to C# to work properly
/// </summary>
public class party : Node {
    
    /// <summary>
    /// PartyEnded signal. Emitted with parameters, when party has finished.
    /// @todo change signal name in the rest of code from "party_ended" to "PartyEnded"
    /// </summary>
    [Signal]
    delegate void PartyEnded(int id, int money, int experience, int musicQuality);
	
    /// <summary>
	/// AnimationPlayer node instance
	/// </summary>
    private AnimationPlayer _animationPlayer;
    
    /// <summary>
    /// Holds string id of currently played party
    /// </summary>
    private string _currentPartyId = "";
    
    /// <summary>
    /// Label instance
    /// </summary>
    private Label _label;
    
    /// <summary>
    /// ColorRect instance
    /// </summary>
    private ColorRect _colorRect;
    
    /// <summary>
    /// List of all done partys
    /// </summary>
    private readonly string[] _donePartys = new string[] { };
    
    /// <summary>
    /// List of all partys' id's
    /// </summary>
    public string[] PartyIds = { "0", "1", "2", "3", "4",};
    
    /// <summary>
    /// Contains data of all party ratings
    /// </summary>
    private readonly Dictionary<string, string> _partyRatings = new Dictionary<string, string>();
	
    /// <summary>
    /// Contains data of all of the partys
    /// </summary>
    private readonly Dictionary<string, int> PartyData = new Dictionary<string, int>() {
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
    public override void _Ready() {
	    _label = (Label)GetNode("CanvasLayer/Label");
	    _colorRect = (ColorRect)GetNode("CanvasLayer/ColorRect");
	    _animationPlayer = (AnimationPlayer)GetNode("CanvasLayer/AnimationPlayer");

	    _label.Hide();
	    _colorRect.Hide();
    }

    /// <summary>
    /// Starts party
    /// </summary>
    /// <param name="id">Party id</param>
    public void StartParty(string id) {
	    _currentPartyId = id;
	    _label.Show();
	    _colorRect.Show();
	    _animationPlayer.Play("party");
    }

    /// <summary>
    /// Calculates rewards for party
    /// </summary>
    /// <param name="id">Party id</param>
    /// <returns>Dictionary of calculated data</returns>
    /// @todo Rewrite GameController to C# to properly access it's variables
    Dictionary<string, int> ComputePartyRewards(string id) {
	    
	    int defaultMoney = PartyData[id + "_base_price"];
	    int defaultExp = PartyData[id + "_base_experience"];
	    int moneyMulti = 0;
	    int expMulti = 0;
	    int musicQualityMulti = 0;
	    int computedMoney = defaultMoney;
	    int computedExp = defaultExp;

	    if (moneyMulti > 0) {
		    computedMoney = defaultMoney + (defaultMoney * moneyMulti);
	    }

	    if (expMulti > 0) {
		    computedExp = defaultExp + (defaultExp * expMulti);
	    }
	    Dictionary<string, int> returnData = new Dictionary<string, int>() {
		    ["money"] = computedMoney,
		    ["exp"] = computedExp,
		    ["music_quality"] = musicQualityMulti
	    };
	    return returnData;
    }

    /// <summary>
    /// Callback for AnimationPlayer's '_on_animation_finished' signal
    /// </summary>
    /// <param name="animName">Name of finished animation</param>
    void AnimationPlayerAnimFinished(string animName) {
	    _colorRect.Hide();
	    _label.Hide();
	    if (animName == "party") {
		    EndParty();
	    }
    }

    /// <summary>
    /// Method ends party executing required callbacks
    /// </summary>
    /// <exception cref="ArgumentNullException">Null exception whether PartyRewards weren't computed properly</exception>
    /// @todo Add getting data from GameController singleton when it will be rewritten to C#
    void EndParty() {
	    Dictionary<string, int> partyRewards = ComputePartyRewards(_currentPartyId) ?? throw new ArgumentNullException("ComputePartyRewards(_currentPartyId)");
	    EmitSignal("PartyEnded", _currentPartyId, partyRewards["money"], partyRewards["exp"], partyRewards["music_quality"]);
	    AddPartyRating(_currentPartyId, new Dictionary<string, string>() {
		    ["experience"] = partyRewards["exp"].ToString(),
		    ["money"] = partyRewards["money"].ToString(),
		    ["m_quality"] = partyRewards["music_quality"].ToString(),
		    //["exp_boost"] = GameController.data["party_experience_earnings_multiplier"],
		    //["money_boost"] = GameController.data["party_money_earnings_multiplier"],
		    //["m_quality_boost"] = GameController.data["party_music_quality_multiplier"]
	    });
    }

    /// <summary>
    /// Adds party rating to database
    /// </summary>
    /// <param name="partyId">Party id</param>
    /// <param name="ratingData">Rating data</param>
    void AddPartyRating(string partyId, Dictionary<string, string> ratingData) {
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
	    return _donePartys.Contains(id);
    }

    /// <summary>
    /// Returns ratings of all done partys
    /// </summary>
    /// <returns>Dictionary of rating data</returns>
    public Dictionary<string, string> GetPartyRatings() {
	    return _partyRatings;
    }
}
