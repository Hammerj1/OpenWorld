using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfData : MonoBehaviour {
    public string name;
    public string namePrefix = "<";
    public string nameSuffix = ">: ";
    private void Awake()
    {
        name = Tools.RandomString(8);
    }
    private void Start()
    {
        
    }
    public void OnConnectedServer()
    {
        GetComponent<Client>().Send("LGN " + name);
    }


    void Update () {
		
	}
}
