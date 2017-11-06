﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsAmount : MonoBehaviour {

    [SerializeField]
    private Text killsText;
    private int kills = 0;

    // Use this for initialization
    void Start () {
        killsText.text = "Kills: " + kills;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddKills ()
    {
        kills++;
        killsText.text = "Kills: " + kills;
    }
}
