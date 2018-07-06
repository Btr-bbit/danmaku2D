using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {
    
    public GameObject currentGun, basicGun;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        processShoot();
	}

    private void processShoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            currentGun = Instantiate(basicGun);
            //currentGun.GetComponent<Emitter>().canFire = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(currentGun);
        }
        if (Input.GetMouseButton(0)) 
        {
            currentGun.transform.position = gameObject.transform.position;
            currentGun.transform.LookAt(Vector3.forward + gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
            Debug.Log(Input.mousePosition);       
        }
        //currentGun.transform.LookAt(Vector3.forward + gameObject.transform.position, Input.mousePosition() - gameObject.transform.position);
    }

}
