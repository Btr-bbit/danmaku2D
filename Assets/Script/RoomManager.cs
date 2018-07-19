﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject[] entrances;
    public GameObject[] enemyWaves;
    public bool started = false;
    public bool ended = false;
    public int wave = 0;
    private int maxWave;

	// Use this for initialization
	void Start () {
        maxWave = enemyWaves.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (wave == maxWave)
        {
            return;
        }

        if (enemyWaves[wave].transform.childCount == 0)
        {
            Destroy(enemyWaves[wave]);
            WaveDestroyed();           
        }
    }

    public void PlayerEnter()
    {
        started = true;
        foreach (GameObject g in entrances)
        {
            g.GetComponent<EntranceController>().CloseDoor();
        }
        if (maxWave > 0)
        {
            enemyWaves[wave].SetActive(true);
        }        
    }

    public void WaveDestroyed()
    {
        wave++;
        Debug.Log(wave);
        if (wave == maxWave)
        {
            started = false;
            ended = true;
            foreach (GameObject g in entrances)
            {
                g.GetComponent<EntranceController>().OpenDoor();
            }
            return;
        }
        else
        {
            Debug.Log("next wave");
            enemyWaves[wave].SetActive(true);
        }
    }
}