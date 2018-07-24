using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelButtonAnim: MonoBehaviour {

    private GameObject def, shine;
    public float changeTime = 1.0f;
    bool mouseOn = false;

    void changeColor(GameObject @object, float speed)
    {
        Color col = @object.GetComponent<Image>().color;
        float alpha = col.a;
        alpha -= Time.deltaTime * speed;
        if (alpha < 0.0f) alpha = 0.0f;
        if (alpha > 1.0f) alpha = 1.0f;
        col.a = alpha;
        @object.GetComponent<Image>().color = col;
    }

    // Use this for initialization
    void Start()
    {
        def = transform.GetChild(0).gameObject;
        shine = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOn)
        {
            changeColor(def, 1.0f / changeTime);
            changeColor(shine, -1.0f / changeTime);
        }
        else
        {
            changeColor(def, -1.0f / changeTime);
            changeColor(shine, 1.0f / changeTime);
        }
    }

    public void mouseEnter()
	{
        mouseOn = true;
	}

    public void mouseExit()
	{
        mouseOn = false;
	}
}
