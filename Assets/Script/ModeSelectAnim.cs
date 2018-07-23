using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectAnim : MonoBehaviour {

    private GameObject def, shine;
    public float changeTime = 1.0f;
    bool mouseOn = false;

    void changeColor(float speed)
    {
        Color col = def.GetComponent<SpriteRenderer>().color;
        float alpha = col.a;
        alpha -= Time.deltaTime / speed;
        if (alpha < 0.0f) alpha = 0.0f;
        if (alpha > 1.0f) alpha = 1.0f;
        col.a = alpha;
        def.GetComponent<SpriteRenderer>().color = col;
    }

	// Use this for initialization
	void Start () 
    {
        def = transform.GetChild(0).gameObject;
        shine = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (mouseOn)
        {
            changeColor(changeTime);
        }
        else
        {
            changeColor(-changeTime);
        }
	}

	private void OnMouseEnter()
	{
        mouseOn = true;
	}

	private void OnMouseExit()
	{
        mouseOn = false;
	}
}
