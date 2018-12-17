using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDestroy()
	{
        GameEventManager.instance.Win();
        Destroy(GameObject.Find("PlayerDummy"));
	}
}
