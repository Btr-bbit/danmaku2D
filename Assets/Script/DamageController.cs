using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
    public float rawDamage = 0.0f;

    DamageController()
    {

    }

    DamageController(float raw)
    {
        this.rawDamage = raw;
    }

	// Use this for initialization
	void Start () {
		
	}
	
    public void SetRawDamage(float newRawDamage)
    {
        this.rawDamage = newRawDamage;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
