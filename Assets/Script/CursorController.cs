using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
    void FixedUpdate () {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vector.z = 0.0f;
        transform.position = vector;
	}
}
