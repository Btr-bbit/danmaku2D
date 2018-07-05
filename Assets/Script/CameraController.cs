using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        transform.position.Set(player.transform.position.x, transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position.Set(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
