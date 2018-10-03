using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerInputField : MonoBehaviour {

    GameObject gameManager;
    Text messageBox;
    public int clientID;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        messageBox = GameObject.Find("DisplayMessageBox").GetComponent<Text>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void GetInputMessage(string input)
    {
        gameManager.GetComponent<Server>().Send(input,clientID);
    }
    public void DisplayMessage(string message)
    {
        messageBox.text = message;
    }
}
