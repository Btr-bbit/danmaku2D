﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingManager : MonoBehaviour {
    public float loadingPercentage = 0.0f, loadingSpeed = 1.0f;
    public GameObject whale, percentage;
    Text percentageText;
    private Vector3 whaleInitPosition;
    public Vector3 whaleSpeed;

	// Use this for initialization
	void Start () {
        //whale = GameObject.Find("whale");
        whaleInitPosition = whale.transform.position;
        //percentageText = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
        percentageText = percentage.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        loadingPercentage += loadingSpeed;
        percentageText.text = ((int)loadingPercentage).ToString() + "%";
        whale.transform.position = whaleInitPosition + (loadingPercentage - 50.0f) / 60.0f * whaleSpeed;
        if (loadingPercentage >= 100.0f)
        {
            SceneController.instance.UnloadScene(SceneController.CurrentScene.loading);
            //SceneController.instance.switch2Game();
        }
	}
}
