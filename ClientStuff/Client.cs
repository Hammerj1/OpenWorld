using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class Client : MonoBehaviour {

    const int max_players = 20;
    int port = 5767;
    int hostID;
    int connectionID;
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
        hostID = NetworkTransport.AddHost(ht, 0);
        //to find server ip type ipconfig in cmd
        connectionID = NetworkTransport.Connect(hostID, "localhost", port, 0,out error);
            
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
            case NetworkEventType.DataEvent:
                Recieve(Encoding.Unicode.GetString(recBuffer, 0, dataSize));
                break;
        }
    }
    void Recieve(string msg)
    {
        GetComponent<GetClientInput>().DisplayMessage(msg);
    }
    public void Send(string data)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(data);
        NetworkTransport.Send(hostID, connectionID, reliableChannel, buffer, data.Length * sizeof(char), out error);
    }
}
