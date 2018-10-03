using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour {
    public Text[] textBoxes = new Text[5];


    public void DisplayMessage(string message)
    {
        for(int i = textBoxes.Length-1; i >= 0; i--)
        {
            if (i == 0)
            {
                textBoxes[i].text = message;
                return;
            }
            textBoxes[i].text = textBoxes[i - 1].text;
        }
    }
}
