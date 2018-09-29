using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetClientInput : MonoBehaviour {
    GameObject gameManager;
    Text messageBox;

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
        gameManager.GetComponent<Client>().Send(input);
    }
    public void DisplayMessage(string message)
    {
        messageBox.text = message;
    }
}
