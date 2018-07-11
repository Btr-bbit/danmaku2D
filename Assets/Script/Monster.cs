using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public GameObject[] reward;
    public int[] rewardNumber;
    int rewardCount;

	// Use this for initialization
	void Start () {
        rewardCount = reward.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
        dropReward();
	}

    void dropReward()
    {
        for (int i = 0; i < rewardCount; i ++)
        {
            for (int j = 0; j < rewardNumber[i]; j ++)
            {
                Instantiate(reward[i], transform.position + Random.insideUnitSphere, transform.rotation);
            }
        }
    }
}