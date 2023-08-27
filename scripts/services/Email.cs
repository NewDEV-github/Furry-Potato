// // Furry Potato Email.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using Godot.Collections;

namespace FurryPotato.Services;

/// <summary>
///     Class for handling email service
///     @copyright New DEV
///     @author DoS
///     @date 2021-09-30
/// </summary>
/// @todo Add methods for receiving emails and reading their data for specific target email
public class Email {
    /// <summary>
    ///     List containing all emails
    /// </summary>
    private readonly Dictionary<string, Dictionary<string, string>> _emails = new();

    /// <summary>
    ///     Function for sending email
    /// </summary>
    /// <param name="to">Target of the email</param>
    /// <param name="subject">Email subject</param>
    /// <param name="body">Email body</param>
    /// <param name="from">Addressed by</param>
    protected void SendEmail(string to, string subject, string body, string from) {
        _emails.Add(_emails.Count + 1 + "", new Dictionary<string, string> {
            { "to", to },
            { "subject", subject },
            { "body", body },
            { "from", from }
        });
    }
}