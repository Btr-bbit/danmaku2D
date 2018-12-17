using System;
using UnityEngine;

public class GhostItem : MonoBehaviour
{
    //持续时间
    public float duration;
    //销毁时间
    public float deleteTime;

    public float destroyLimitAlpha = 0.01f;
	private void Start()
	{
        
	}
	void Update(){
        float tempTime = deleteTime - Time.time;
        Color col = gameObject.GetComponent<SpriteRenderer>().color;

        if (tempTime <= 0 || col.a < destroyLimitAlpha) {//到时间就销毁
            Destroy (this.gameObject);
        } else {
            float rate = tempTime/duration;//计算生命周期的比例

            col.a *= 0.8f;//设置透明通道
            gameObject.GetComponent<SpriteRenderer>().color = col;
        }
    }
}