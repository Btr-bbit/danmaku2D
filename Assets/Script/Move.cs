using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//运动方程 :  位移=方向*Speed*速度曲线加权+Offset曲线加权
//X为右方向，Y为前方向
public class Move : MonoBehaviour {

    public float xSpeed = 0f;
    public float ySpeed = 1f;
    public bool useCurve = false;
    public AnimationCurve speedXcurve;
    public AnimationCurve speedYcurve;
    public AnimationCurve offsetXcurve;
    public AnimationCurve offsetYcurve;
    // Use this for initialization
    public float time = 0;
    void Start () {

    }

    private void FixedUpdate()
    {
        if (!useCurve)
        {
            transform.position += Time.deltaTime * transform.up * ySpeed;
            transform.position += Time.deltaTime * transform.right * xSpeed;
        }
        else
        {
            transform.position += Time.deltaTime * (transform.up * ySpeed * speedYcurve.Evaluate(time) + transform.up * offsetYcurve.Evaluate(time));
            transform.position += Time.deltaTime * (transform.right * xSpeed * speedXcurve.Evaluate(time) + transform.right * offsetXcurve.Evaluate(time));
        }
        time += Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
        if (DanmakuManager.IsOutOfBounds(transform))
            Destroy(gameObject);
	}
}
