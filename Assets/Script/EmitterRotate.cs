using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//旋转公式：角度
public class EmitterRotate : MonoBehaviour {

    public float speed = 30f;
	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
