using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MessageCommandCenter {
    /// <summary>
    /// Main Command center
    /// <para>Command Types</para>
    /// <para>POS X Y Z * Sends player position to server</para>
    /// <para>GPO P * Sends back the position of player with id of P</para>
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
        }
    }
    public static void ConnectPlayer(int playerID)
    {
        PlayerData.AddPlayer(playerID.ToString(),playerID); 
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
        Server.SendMessage(message, sender);
    }    
}
