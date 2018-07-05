using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //身上无敌效果层数（大于1时具有无敌）
    public int invincibleLayer = 0;
    //是否正处于躲避状态（躲避时无法控制方向，躲避且无敌时不会碰撞子弹）
    public bool isDodging = false;
    //躲避的无敌时间
    public float invincibleDodgeTime;
    //躲避动画的总时间
    public float totalDodgeTime;
    //基础移动速度
    public float moveBaseSpeed;
    //躲避时的速度曲线
    public AnimationCurve dodgeSpeed;
    //角色现在的移动速度
    public float moveSpeed;
    //角色现在的移动方向
    public Vector3 moveDirection = Vector3.zero;

    //上下左右移动对应按键
    private KeyCode moveLeftKey, moveRightKey, moveForwardKey, moveBackKey;
    //闪避对应按键
    private KeyCode dodgeKey;

    // Use this for initialization
    void Start () {
        //transform.LookAt(Input.mousePosition);
        moveSpeed = moveBaseSpeed;
        moveLeftKey = KeyCode.A;
        moveRightKey = KeyCode.D;
        moveForwardKey = KeyCode.W;
        moveBackKey = KeyCode.S;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(Input.mousePosition);
        processMovement();
        processDodge();

        if (invincibleLayer < 0)
        {
            invincibleLayer = 0;
        }
	}

    public bool isVincible()
    {
        return (invincibleLayer > 0);
    }

    private void processMovement()
    {
        if (isDodging)
        {
            return;
        }

        moveDirection = Vector3.zero;
        if (Input.GetKey(moveLeftKey))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(moveRightKey))
        {
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(moveForwardKey))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(moveBackKey))
        {
            moveDirection += Vector3.down;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void processDodge()
    {
        if (isDodging)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isDodging = true;
            StartCoroutine(__processDodge());
        }
    }

    private IEnumerator __processDodge()
    {
        float passedTime = 0;
        moveSpeed = dodgeSpeed.Evaluate(passedTime);
        invincibleLayer += 1;
        bool flag = false;
        while (passedTime < totalDodgeTime)
        {
            yield return new WaitForEndOfFrame();
            passedTime += Time.deltaTime;
            moveSpeed = dodgeSpeed.Evaluate(passedTime);
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            if ((!flag) && (passedTime > invincibleDodgeTime))
            {
                invincibleLayer -= 1;
                flag = true;
            }
        }
        isDodging = false;
        moveSpeed = moveBaseSpeed;
    }
}
