using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputStringDialog : MessageDialog {
    public InputField input;
    public string GetInputText()
    {
        return input.text;
    }

    public void SetInputText(string msg)
    {
        input.text = msg;
    }
}
