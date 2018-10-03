using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class Server : MonoBehaviour {
    const int max_players = 20;
    int port = 5767;
    int hostID;
    int unreliabeChannel;
    int reliableChannel;
    byte error;

    private void Start()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();
        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliabeChannel = cc.AddChannel(QosType.Unreliable);
        HostTopology ht = new HostTopology(cc, max_players);
        hostID = NetworkTransport.AddHost(ht, port, null);
    }
    private void Update()
    {
        
        int recHostID;
        int connectionID;
        int channelID;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;

        NetworkEventType recData = NetworkTransport.Receive(out recHostID, out connectionID, out channelID, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {
            case NetworkEventType.Nothing:
                break;
            case NetworkEventType.ConnectEvent:
                Debug.Log("Player " + connectionID + " has connected!");
                Send("SRT", connectionID);
                //MessageCommandCenter.ConnectPlayer(connectionID);
                break;
            case NetworkEventType.DataEvent:
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                //GetComponent<ServerInputField>().DisplayMessage(msg);
                MessageCommandCenter.EnterMessage(msg, connectionID);
                break;
            case NetworkEventType.DisconnectEvent:
                Debug.Log("Player " + connectionID + " has disconnected!");
                MessageCommandCenter.DisconnectPlayer(connectionID);
                break;
                
        }
    }
    public void Send(string data, int playerID)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(data);
        NetworkTransport.Send(hostID, playerID, reliableChannel, buffer, data.Length * sizeof(char), out error);

    }


}
