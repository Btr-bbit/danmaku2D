using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControll : MonoBehaviour {

    private Vector3 InitPosition;
    public float eyesRange = 0.1f;
	// Use this for initialization
	void Start () {
        InitPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - InitPosition;
        float len = Mathf.Sqrt(pos.x * pos.x + pos.y * pos.y);
        if (len > eyesRange)
        {
            //pos.Normalize();
            pos.x *= eyesRange / len;
            pos.y *= eyesRange / len;
        }
        Vector3 targetPos = InitPosition + pos;
        targetPos.z = 0.0f;
        transform.position = targetPos;
        //Debug.Log(transform.position);
	}
}
