using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetClientInput : MonoBehaviour {

    Chatbox messageBox;
    SelfData player;

    private void Awake()
    {
        player = GetComponent<SelfData>();
        messageBox = GameObject.Find("ChatBar").GetComponent<Chatbox>();
    }

    public void OutputMessage(string input)
    {
        messageBox.DisplayMessage(input);
    }

    public void OnInputEnter(string input)
    {
        GetComponent<Client>().Send("MSG " + player.namePrefix + player.name + player.nameSuffix + input);
        //OutputMessage(player.namePrefix + player.name + player.nameSuffix + input);
    }
}
