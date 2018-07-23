using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
        
	}

    // Update按场景中顺序执行，使用LateUpdate强制相机跟随最后执行
    void LateUpdate()
    {
        if (player != null)
        {
            //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            Vector3 v = Vector3.Lerp(player.transform.position, Input.mousePosition, 0.005f);
            v.z = -10;
            transform.position = v;
        }
    }
}