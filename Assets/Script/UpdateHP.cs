﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHP : MonoBehaviour {

	private Text t;
	private HPRecorder playerHP;
	// Use this for initialization
	void Start () {
		GameObject p = GameObject.Find("小KUN");
		if (p == null) Debug.Log("cannot find the player!");
        playerHP = p.GetComponent<HPRecorder>();

		t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		t.text = "HP: " + Mathf.Floor(playerHP.hp).ToString();
	}
}
