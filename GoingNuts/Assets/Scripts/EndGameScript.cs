﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameScript : MonoBehaviour {

    public GameObject prompt;
    public GameObject player;
    float pickups;
    float seconds;
    bool asked;

	// Use this for initialization
	void Start () {
        prompt.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (asked == true)
        {
            prompt.SetActive(true);
        }
        else
        {
            prompt.SetActive(false);
        }
        if (asked == true && Input.GetKeyUp(KeyCode.Return))
        {
            pickups = player.GetComponent<PlayerStats>().totalPickups;
            seconds = player.GetComponent<PlayerStats>().totalTime;
            PlayerPrefs.SetFloat("Total_Pickups", pickups);
            PlayerPrefs.SetFloat("Total_Time", seconds);
            GoToScript goTo = new GoToScript();
            goTo.score();
        }
	}

    void OnTriggerEnter (Collider col) {
        if (col.tag == "Player")
        {
            asked = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            asked = false;
        }
    }
}
