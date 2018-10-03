using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClientCommandCenter {

	public static void Command(string msg)
    {
        string[] data = msg.Split(' ');
        switch (data[0])
        {
            case "GNS":
                RecieveNameList(data);
                break;
            case "MSG":
                RecieveMessageInput(data);
                break;
            case "SRT":
                StartClient();
                break;

        }
    }
    static void RecieveNameList(string[] data)
    {

        for (int i = 1; i < data.Length; i++)
        {
            GameObject.Find("ChatBar").GetComponent<Chatbox>().DisplayMessage(data[i]);
        }
        
    }
    static void RecieveMessageInput(string[] data)
    {
        string message = Tools.CombineStrings(data);
        message = message.Substring(4, message.Length-4);
        GameObject.Find("ChatBar").GetComponent<Chatbox>().DisplayMessage(message);


    }
    static void StartClient()
    {
        GameObject.Find("Client").GetComponent<SelfData>().OnConnectedServer();
    }

}
