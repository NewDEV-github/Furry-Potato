// // Furry Potato R1S1_MAIN.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using Godot.Collections;

namespace FurryPotato.Utils.UI.DialogueLines.R1S1;

/// <summary>
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-28
/// </summary>
public class R1S1_MAIN : DialogueLine {
    /// <summary>
    ///     Name of this dialogue line
    /// </summary>
    public override string Name { get; set; } = "R1S1_MAIN";

    /// <summary>
    ///     Array of characters in the dialogue line
    /// </summary>
    public override Array<string> Characters { get; set; } = new() { "Player" };

    /// <summary>
    ///     Dictionary of lines in the dialogue line. Key is the character name, value is the line.
    /// </summary>
    public override Dictionary<string, string> Lines { get; set; } = new() {
        {
            "0",
            "W końcu nadszedł ten dzień. Dziś odbędzie się konkurs DJ’ów, w którym mam szansę pokazać swoje umiejętności i zdobyć uznanie."
        },
        { "1", "To może być przełom w mojej karierze. Muszę się dobrze przygotować i dać z siebie wszystko." },
        { "2", "Ale co ja mam zagrać? Mam tyle płyt, że nie wiem, co wybrać." }, {
            "3",
            "Chcę zrobić dobry mix, który będzie pasował do nastroju imprezy, zaskoczy jury i zachwyci publiczność."
        },
        { "4", "Może powinienem się skupić na jednym gatunku muzycznym? Albo spróbować połączyć różne style? " },
        { "5", "Albo zagrać coś zupełnie nowego i oryginalnego?" },
        { "6", "Hmm… Mam kilka pomysłów, ale nie wiem, który będzie najlepszy. Muszę podjąć decyzję." },
        { "CHOICE", "CHOICE" }
    };

    /// <summary>
    ///     Choices: Dictionary of choices in the dialogue line. Key is the line after the choice will appear, value is the
    ///     dictionary of choices.
    /// </summary>
    public override Dictionary<int, Dictionary<int, string>> Choices { get; set; } = new() {
        {
            0, new Dictionary<int, string> {
                { 0, "Zagraj techno" },
                { 1, "Zagraj house" },
                { 2, "Zagraj trance" },
                { 3, "Zagraj hip-hop" },
                { 4, "Zagraj rock" },
                { 5, "Zagraj pop" },
                { 6, "Zagraj coś innego" }
            }
        }
    };
}