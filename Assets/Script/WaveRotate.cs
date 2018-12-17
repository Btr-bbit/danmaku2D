using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//旋转公式：角度
public class WaveRotate : MonoBehaviour
{

    public float speed = 30f;
    private float elapsedTime = 0;
    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Mathf.Sin(elapsedTime) * Time.deltaTime);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 10 * Mathf.PI)
        {
            elapsedTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
