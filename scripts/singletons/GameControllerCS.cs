using Godot;
using Godot.Collections;
using NewDEVSharp;

/// <summary>
/// Game Core in C#, used for doing C# things in core, that can't be done in Godot at game core
/// </summary>
public class GameControllerCS : CSharpCore {
        /// <summary>
        /// Current name of current save
        /// </summary>
        public string CurrentSaveName = "NewSave";
        
        /// <summary>
        /// Data dictionary of multipliers
        /// </summary>
        private Dictionary<string, float> _multipliers = new Dictionary<string, float>() {
                ["party_money_earnings_multiplier"] = 0.0f,
                ["party_experience_earnings_multiplier"] = 0.0f,
                ["party_music_quality_multiplier"] = 0.0f
        };
        
        /// <summary>
        /// Data dictionary of all string-type data
        /// </summary>
        private Dictionary<string, string> _data = new Dictionary<string, string>() {
                ["DJName"] = "DJName",
                ["PlayerEmailDomain"] = "furry.potato"
        };

        /// <summary>
        /// Data dictionary of all integer-type data
        /// </summary>
        private Dictionary<string, int> _intData = new Dictionary<string, int>() {
                ["money"] = 0,
                ["experience"] = 0
        };

        /// <summary>
        /// Sets new data to _intData
        /// </summary>
        /// <param name="newData">New data to set</param>
        public void SetNewIntsDataFields(Dictionary<string, int> newData) {
                _intData = newData;
        }
        
        /// <summary>
        /// Sets new data to _data
        /// </summary>
        /// <param name="newData">New data to set</param>
        public void SetNewStringsDataFields(Dictionary<string, string> newData) {
                _data = newData;
        }

        /// <summary>
        /// Sets new data to _multipliers
        /// </summary>
        /// <param name="multiData">New data to set</param>
        public void SetNewMultiplierData(Dictionary<string, float> multiData) {
                _multipliers = multiData;
        }
        
        /// <summary>
        /// Sets DJ's name
        /// </summary>
        /// <param name="newName">DJ's name</param>
        public void SetDJName(string newName) {
                _data["DJName"] = newName;
        }

        /// <summary>
        /// Sets new in-game email domain
        /// </summary>
        /// <param name="newEmailDomain">New domain to set</param>
        public void SetNewEmailDomain(string newEmailDomain) {
                _data["PlayerEmailDomain"] = newEmailDomain;
        }

        /// <summary>
        /// Sets new multiplier value in _multipliers according to given multiplier name
        /// </summary>
        /// <param name="multiplierName">Multiplier name</param>
        /// <param name="multiplierValue">Multiplier float value</param>
        public void SetNewMultiplierValue(string multiplierName, float multiplierValue) {
                _multipliers[multiplierName] = multiplierValue;
        }
        
        /// <summary>
        /// Adds money
        /// </summary>
        /// <param name="amount">Amount of money to add</param>
        public void AddMoney(int amount) {
                _intData["money"] += amount;
        }
        
        /// <summary>
        /// Adds experience points
        /// </summary>
        /// <param name="amount">Amount of experience points to add</param>
        public void AddExperience(int amount) {
                _intData["experience"] += amount;
        }

        /// <summary>
        /// Returns amount of currently stored by player money
        /// </summary>
        /// <returns>Amount of money</returns>
        public int GetMoney() {
                return _intData["money"];
        }

        /// <summary>
        /// Returns amount of currently gained by player experience points
        /// </summary>
        /// <returns>Amount of experience points</returns>
        public int GetExperience() {
                return _intData["experience"];
        }

        /// <summary>
        /// Starts new game by setting everywhere default values
        /// </summary>
        public void StartNewGame() {
                _intData = new Dictionary<string, int>() {
                        ["money"] = 0,
                        ["experience"] = 0
                };
                _data = new Dictionary<string, string>() {
                        ["DJName"] = "DJName",
                        ["PlayerEmailDomain"] = "furry.potato"
                };
                _multipliers = new Dictionary<string, float>() {
                        ["party_money_earnings_multiplier"] = 0.0f,
                        ["party_experience_earnings_multiplier"] = 0.0f,
                        ["party_music_quality_multiplier"] = 0.0f
                };
                CurrentSaveName = "NewSave";
        }

        /// <summary>
        /// Returns _data dictionary
        /// </summary>
        /// <returns>_data dictionary</returns>
        public Dictionary<string, string> GetStrings() {
                return _data;
        }
        
        /// <summary>
        /// Returns _intData dictionary
        /// </summary>
        /// <returns>_intData dictionary</returns>
        public Dictionary<string, int> GetInts() {
                return _intData;
        }
        
        /// <summary>
        /// Returns _multipliers dictionary
        /// </summary>
        /// <returns>_multipliers dictionary</returns>
        public Dictionary<string, float> GetFloats() {
                return _multipliers;
        }
}
