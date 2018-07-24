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
            //Debug.Log("restart");
            SceneController.instance.switch2Pick();
        } else if (gameObject.name == "Exit") {
            SceneController.instance.switch2Title();
            //Debug.Log("exit");
        }
    }
}
