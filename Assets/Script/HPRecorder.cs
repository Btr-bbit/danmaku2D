using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPRecorder : MonoBehaviour {
    public UnityEvent onHPZero = new UnityEvent();
    public float hp;
    public float modifier = 1.0f;
    private GameObject deathAnimation;

    // Use this for initialization
    void Start () {
		//deathAnimation = GameObject.Find("effects manager").GetComponent<EffectManager>().deathEffect;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetModifier(float newModifier)
    {
        this.modifier = newModifier;
    }

    public void ResetModifier()
    {
        this.modifier = 1.0f;
    }

    public float GetHit(float damage)
    {
        float realDamage = damage * modifier;
        hp -= realDamage;
        if (hp <= 0)
        {
            onHPZero.Invoke();
            //Instantiate(deathAnimation,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        return realDamage;
    }
}
