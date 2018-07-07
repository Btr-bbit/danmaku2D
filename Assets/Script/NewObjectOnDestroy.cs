using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewObjectOnDestroy : MonoBehaviour {
    public GameObject destroyAnimation;
    public GameObject[] newObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        if (destroyAnimation != null)
        {
            Instantiate(destroyAnimation, gameObject.transform.position, Quaternion.identity);
        }

        foreach (GameObject go in newObjects)
        {
            Instantiate(go, gameObject.transform.position, Quaternion.identity);
        }
    }
}
