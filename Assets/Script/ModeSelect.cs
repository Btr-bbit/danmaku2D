﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseUpAsButton()
	{
        //Debug.Log("Mouse Over");
        if (gameObject.name == "SinglePlayer")
        {
            GameMode.playingMode = GameMode.PlayingMode.singlePlayer;
        }
        else if (gameObject.name == "MultiPlayer")
        {
            GameMode.playingMode = GameMode.PlayingMode.multiPlayer;
        }
        else if (gameObject.name == "Exit")
        {
            Application.Quit();
        }
	}

	private void OnMouseOver()
	{
        
	}
	
}
