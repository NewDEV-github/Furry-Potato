// // Furry Potato OptionItem.cs is under
// // Copyright (c) of New DEV - 2023
// //All rights reserved


using System;
using Godot;
using Godot.Collections;

namespace FurryPotato.Utils;

/// <summary>
///     Class for handling option item's
///     @copyright New DEV
///     @author DoS
///     @date 2023-09-27
/// </summary>
public partial class OptionItem : HBoxContainer {
    private int _currentOptionIndex;

    /// <summary>
    ///     If is only true/false, then treat values as booleans not strings
    /// </summary>
    /// @todo Add option for volume types
    /// @todo Add slider handling
    [Export] private bool _isTrueOrFalse;

    /// <summary>
    ///     Loads option item and configures it
    ///     @todo Add option item configuration
    /// </summary>
    /// <summary>
    ///     Option name
    /// </summary>
    [Export] private string _optionName = "";

    private Label _optionNameLabel;

    /// <summary>
    ///     Array of string options
    /// </summary>
    [Export] private Array<string> _options = new();

    private Label _optionValueLabel;

    /// <summary>
    ///     Set ups option item
    /// </summary>
    public override void _Ready() {
        _optionNameLabel = GetNode<Label>("OptionName");
        _optionValueLabel = GetNode<Label>("Options/OptionValue");
        var optionValueContainer = GetNode<HBoxContainer>("Options");
        var optionCheckbox = GetNode<CheckBox>("CheckBox");
        _optionNameLabel.Text = _optionName;
        _optionValueLabel.Text = _isTrueOrFalse ? "" : _options[_currentOptionIndex];
        if (_isTrueOrFalse) {
            optionValueContainer.Hide();
            optionCheckbox.Show();
        }
        else {
            optionValueContainer.Show();
            optionCheckbox.Hide();
        }

        GD.Print("Item ready!");
    }

    /// <summary>
    ///     Selects previous option from option list
    /// </summary>
    public void SelectPreviousOption() {
        GD.Print("Previous option selected!");
        if (_currentOptionIndex == 0)
            _currentOptionIndex = _options.Count - 1;
        else
            _currentOptionIndex--;
        _optionValueLabel.Text = _options[_currentOptionIndex];
    }

    /// <summary>
    ///     Selects next option from option list
    /// </summary>
    public void SelectNextOption() {
        GD.Print("Next option selected!");
        if (_currentOptionIndex == _options.Count - 1)
            _currentOptionIndex = 0;
        else
            _currentOptionIndex++;
        _optionValueLabel.Text = _options[_currentOptionIndex];
    }

    /// <summary>
    ///     Sets specific option from option list
    /// </summary>
    /// <param name="option">Option name</param>
    /// <exception cref="NotSupportedException">Exception, if option value is not supported</exception>
    /// @todo Handle setting string values
    /// @todo Handle setting boolean values
    public void SetSpecificOption(string option) {
        var optionCheckbox = GetNode<CheckBox>("CheckBox");
        if (!_isTrueOrFalse) {
            if (_options.Contains(option)) {
                _currentOptionIndex = _options.IndexOf(option);
                _optionValueLabel.Text = _options[_currentOptionIndex];
            }
            else {
                throw new NotSupportedException("This value is not supported!");
            }
        }
        else {
            optionCheckbox.ButtonPressed = option switch {
                "true" => true,
                "True" => true,
                "TRUE" => true,
                "false" => false,
                "False" => false,
                "FALSE" => false,
                _ => throw new NotSupportedException("This value is not supported!")
            };
        }

        GD.Print("Specific option selected!");
    }

    /// <summary>
    ///     Gets value of this item
    /// </summary>
    /// <returns>Value</returns>
    public string GetValue() {
        var value = "";
        if (_isTrueOrFalse) {
            var optionCheckbox = GetNode<CheckBox>("CheckBox");
            value = optionCheckbox.ButtonPressed ? "true" : "false";
        }
        else {
            value = _options[_currentOptionIndex];
        }

        return value;
    }
}