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
        gameObject.GetComponent<HPRecorder>().onHit = new HPRecorder.OnHit(OnHit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
	}

    void OnHit(float NowHP, float Damage)
    {
        if (NowHP <= 0)
        {
            dropReward();
        }
    }

    void dropReward()
    {
        for (int i = 0; i < rewardCount; i ++)
        {
            for (int j = 0; j < rewardNumber[i]; j ++)
            {
                Instantiate(reward[i], transform.position + Random.insideUnitSphere*0.1f, transform.rotation);
            }
        }
    }
}