using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject[] entrances;
    public GameObject[] enemyWaves;
    public bool started = false;
    public bool ended = false;
    public int wave = 0;
    public float spawnWait = 1;
    private int maxWave;
    private bool readyForNext = true;

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

        if ((enemyWaves[wave].transform.childCount == 0) && (readyForNext))
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
            StartCoroutine(nextWave());
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
            StartCoroutine(nextWave());
        }
    }

    private IEnumerator nextWave()
    {
        readyForNext = false;
        yield return new WaitForSeconds(spawnWait);
        Debug.Log("next wave");
        enemyWaves[wave].SetActive(true);
        readyForNext = true;
    }
}
