﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun
{
    public enum Type {
        BasicGun,
        BombGun,
        FlameThrower,
        ShotGun,
        SniperGun
    };
    public Type type;//枪支名称(作为索引)
    public GameObject emitter;//产生子弹的Emitter，需要在开枪时生成，停止开枪时销毁
    public float clickInterval;//两次发射之间的最小时间间隔(鼠标两次点击间)
    //以及一些控制枪支动画/模型的成员
}

public class GunManager : MonoBehaviour {

    static public GunManager instance;
    public Gun[] guns;//设计的全部枪支列表
    public List<int> ownedGuns;//玩家当前拥有的枪支ID
    private Gun nowGun = null;//当前持握的枪支

    public GameObject currentGun;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(guns != null);
        if (instance == null)
            instance = this;
        else
        {
            Debug.LogWarning("Find more than one GunManager in scene!");
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        changeGun();
        processShoot();
	}

    private void processShoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (currentGun != null)
            {
                Destroy(currentGun);
            }
            if (nowGun != null)
                currentGun = Instantiate(nowGun.emitter);
            else
                Debug.Log("You are not equipped with a gun!");
            //currentGun.GetComponent<Emitter>().canFire = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(currentGun);
            currentGun = null;
        }
        if (Input.GetMouseButton(0)) 
        {
            if (currentGun != null)
            {
                currentGun.transform.position = gameObject.transform.position;
                currentGun.transform.LookAt(Vector3.forward + gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
            }
        }
        //currentGun.transform.LookAt(Vector3.forward + gameObject.transform.position, Input.mousePosition() - gameObject.transform.position);
    }

    //数字键切枪
    private void changeGun()
    {
        //判断用户是否按下上方数字键1-9，切枪
        for(int i=1;i<=9;i++)
        if (Input.GetKeyDown(KeyCode.Alpha0+i))
        {
                //列表里有此枪
                if (ownedGuns.Count >= i)
                    nowGun = guns[ownedGuns[i]];
        }
    }

}
