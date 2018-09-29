using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData{
    static List<APlayer> players = new List<APlayer>();
    static List<APlayer> onlinePlayers = new List<APlayer>();
    static Vector3 spawnPosition;

    public static void AddPlayer(string name, int id)
    {
        
        if(FindPlayer(name) == null)
        {
            players.Add(new APlayer(name, Tools.RandomVector()));
            onlinePlayers.Add(FindPlayer(name));
            FindPlayer(name).OnConnect(id);
        }
        else
        {
            FindPlayer(name).OnConnect(id);
            onlinePlayers.Add(FindPlayer(name));
        }
    }
    public static void DisconnectPlayer(string name)
    {
        onlinePlayers.Remove(FindPlayer(name));
        FindPlayer(name).OnDisconnect();
    }
    #region Find Players
    /// <summary>
    /// Gets online player with current connection ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static APlayer GetPlayer(int id)
    {
        foreach (APlayer p in players)
        {
            if (id != 0)
            {
                if (p.ConnectID() == id)
                {
                    return p;
                }
            }
        }
        return null;

    }
    /// <summary>
    /// Gets player given their name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    static APlayer FindPlayer(string name)
    {
        foreach(APlayer p in players)
        {
            if(name != null)
            {
                if (p.Name() == name)
                {
                    return p;
                }                
            }
        }
        return null;
    }
    #endregion
}
#region PlayerClass
public class APlayer
{
    string playerName;
    Vector3 position;
    int currentConnectionID;


    public APlayer(string name, Vector3 pos)
    {
        position = pos;
        playerName = name;
    }
    public void OnConnect(int id)
    {
        currentConnectionID = id;
    }
    public void OnDisconnect()
    {
        currentConnectionID = -1;
    }
    public void changePosition(Vector3 pos)
    {
        position = pos;
    }
    public string Name()
    {
        return playerName;
    }
    public Vector3 Position()
    {
        return position;
    }
    public int ConnectID()
    {
        return currentConnectionID;
    }
}
#endregion
