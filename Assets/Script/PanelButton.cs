using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void mouseClick() {
        if (gameObject.name == "Restart") {
            Debug.Log("restart");
        } else if (gameObject.name == "Exit") {
            Debug.Log("exit");
        }
    }
}
