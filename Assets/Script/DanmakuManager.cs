using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//综合管理类，提供共用辅助函数
public class DanmakuManager : MonoBehaviour {

    public static DanmakuManager instance;
    [SerializeField]
    public GameObject player;
    
    public static bool IsOutOfBounds(Transform t)
    {
        if (t.position.x < -8) return true;
        if (t.position.x > 8) return true;
        if (t.position.y < -6) return true;
        if (t.position.y > 6) return true;
        return false;
    }

    // Use this for initialization
    void Start () {
        if (instance)
            Destroy(this);
        else
            instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
