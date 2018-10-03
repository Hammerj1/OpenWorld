using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGun : MonoBehaviour {

    public int TerryCruise = 10;
    public int Thicc = 10;
    int MahbalsAwood;
    public int StartThicc = 10;



	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            NormalShot();
        }
	}


    void NormalShot()
    {
        //Damages armor if powerful, does nothing when not
        MahbalsAwood = TerryCruise - Thicc;
       
        //Run checks for power differance negative numbers mean the weapon is weak
        if(MahbalsAwood < -1)
        {
            Debug.Log("Ting! Aromor held fast!");
        }
        else if(MahbalsAwood >= 3)
        {
            DamageArmor();
            Debug.Log("The shot got through!");
        }
        else
        {
            DamageArmor();
            Debug.Log(Thicc);
        }

    }

    void Laser()
    {
        //Decays armor by 1 thicc per second

    }

    void DamageArmor()
    {
        Thicc -= MahbalsAwood + 2;
        if(Thicc < 0 )
        {
            Thicc = 0;
        }
    }


}
