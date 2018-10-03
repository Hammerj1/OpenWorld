using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class MessageCommandCenter {
    /// <summary>
    /// Main Command center
    /// <para>Command Types</para>
    /// <para>POS X Y Z * Sends player position to server</para>
    /// <para>GPO P * Sends back the position of player with id of P</para>
    /// <para>MSG S * Displays a chat message the client has sent to the server</para>
    /// <para>LGN N * Creates a player with the name of N</para>
    /// <para>SNS</para>
    /// </summary>
    /// <param name="msg"></param>
	public static void EnterMessage(string msg, int senderID)
    {
        string[] data = msg.Split(' ');
        switch (data[0])
        {
            case "POS":
                UpdatePostion(data[1], data[2], data[3], senderID);
                break;
            case "GPO":
                GetPosition(data[1], senderID);
                break;
            case "MSG":
                ChatMessage(data);
                break;
            case "LGN":
                Login(data[1], senderID);
                break;
            case "SNS":
                SendNames(senderID);
                break;
        }
    }
    public static void ConnectPlayer(int playerID)
    {

    }
    public static void DisconnectPlayer(int playerID)
    {
        PlayerData.DisconnectPlayer(PlayerData.GetPlayer(playerID).Name());
    }
	static void UpdatePostion(string x, string y, string z, int playerID)
    {
        Vector3 pos = new Vector3(int.Parse(x), int.Parse(y), int.Parse(z));
        PlayerData.GetPlayer(playerID).changePosition(pos);
    }
    static void GetPosition(string p, int sender)
    {
        int player = int.Parse(p);
        Vector3 pos = PlayerData.GetPlayer(player).Position();
        
        SendPosition(pos, sender);
    }
    public static void SendPosition(Vector3 pos, int sender)
    {
        string message = ("GPO " + pos.x + " " + pos.y + " " + pos.z);
        GameObject.Find("Server").GetComponent<Server>().Send(message, sender);
    }    
    static void ChatMessage(string[] msg)
    {
        string message = Tools.CombineStrings(msg);
        Debug.Log(message);
        message = message.Substring(4, message.Length-4);
        GameObject.Find("ChatBar").GetComponent<Chatbox>().DisplayMessage(message);
        for(int i = 0; i < PlayerData.PlayersOnline(); i++)
        {
            GameObject.Find("Server").GetComponent<Server>().Send("MSG " + message, i + 1);
        }
    }
    static void Login(string name, int id)
    {
        Debug.Log("Connected");
        PlayerData.AddPlayer(name, id);
    }
    static void SendNames(int id)
    {
        List<string> names = PlayerData.getPlayers();
        string nameList = null;
        for(int i = 1; i < names.Count; i++)
        {
            names[i] = ' ' + names[i-1] + ' ' + names[i];
            nameList = names[i];
        }
        GameObject.Find("Server").GetComponent<Server>().Send("GNS" + nameList, id);
    }
}

