// // Furry Potato R1S2_MAIN.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved

using Godot.Collections;

namespace FurryPotato.Utils.UI.DialogueLines.R1S1;

/// <summary>
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-28
/// </summary>
public class R1S2_MAIN : DialogueLine {
    /// <summary>
    ///     Name of this dialogue line
    /// </summary>
    public override string Name { get; set; } = "R1S1_MAIN";

    /// <summary>
    ///     Array of characters in the dialogue line
    /// </summary>
    public override Array<string> Characters { get; set; } = new() { "Speaker", "Player", "Player", "Speaker", "Speaker" };

    /// <summary>
    ///     Dictionary of lines in the dialogue line. Key is the character name, value is the line.
    /// </summary>
    public override Dictionary<string, string> Lines { get; set; } = new() {
        {
            "0",
            "Witamy na scenie kolejnego uczestnika konkursu DJ’ów! Przed wami DJ _dj_name_, który zagra dla nas _selected_genre_! Dajcie mu głośny aplauz!"
        },
        { "1", "To jest to. Moja szansa, żeby się pokazać. Muszę dać z siebie wszystko i nie zawieść. Nie mogę się stresować i popełnić błędu. Muszę się skupić na muzyce i cieszyć się nią..." },
        { "2", "To było niesamowite. Czułem się jak w transie. Nie wiem, jak długo grałem, ale wydawało mi się, że to była wieczność. Czy podobało się to ludziom? Czy zrobiłem dobre wrażenie? Czy spełniłem oczekiwania?" }, {
            "3",
            "Brawo, brawo! Co za występ! To był _selected_genre_ w najlepszym wydaniu! Jak wam się podobało, drodzy słuchacze?"
        },
        { "4", "A teraz czas na ocenę jury. Co o tym myślicie, drodzy jurorzy?" },
        //@todo: Add jury lines
        { "END", "END" }
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