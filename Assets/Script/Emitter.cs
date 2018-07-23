using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomFunction //用于单个子弹初始化时的随机化，作为Emitter的参数表
{
    /*
     * 随机函数方法：随机产生0-1中的若干实数，选择对应曲线中对应位置的值作为变换参数
     * 采用Union设计方法，单参数变化仅曲线1有效，双参数为曲线1/2有效，其他曲线为No-Effect
     * 0：Rotate 将物体随机旋转角度(参数1:角度)
     * 1：Position 随机移动物体XY坐标(参数1:X 参数2:Y)
     */
    public enum Type { Rotate, Position };
    public Type type;
    public AnimationCurve ac1,ac2;
    //将改随机化效果作用于物体
    public void Acting(GameObject obj)
    {
        float r1 = Random.Range(0.0f, 1.0f);
        float r2 = Random.Range(0.0f, 1.0f);
        switch (type)
        {
            case Type.Rotate:
                obj.transform.Rotate(0, 0, ac1.Evaluate(r1));
                break;
            case Type.Position:
                obj.transform.position += new Vector3(ac1.Evaluate(r1), ac2.Evaluate(r2), 0);
                break;
            default:
                Debug.LogWarning("Unknown RandomFunction Type!");
                break;
        }
    }
}

//子弹发射器
//每轮发射循环实例化bullet列表中的元素
public class Emitter : MonoBehaviour {
    public bool tracking = false; //生成的我物体是否指向目标(敌机)
    public bool worldSpace = true; //生成的物体是否是世界坐标(false为跟随emitter)
    public GameObject[] bullet; //子弹列表
    public float roundTime; //每轮发射间隔时间
    public float startTime; //初始时间偏移(时间计数器，倒计时到0发射一轮)
    public int EmitRound = -1; //-1表示无限发射，否则发射Round轮
    public float EmitAngle = 0; //发射的扇形角度(默认以up方向为中轴均分)
    public int EmitNumber = 1; //每轮发射的子弹个数(配合Angle参数发射扇形子弹)
    public bool randomSelectBullet = false; //若为True则每轮随机从列表中选择一种弹幕
    public RandomFunction[] randomFunction = null; //发射子弹时将会对每个子弹依次作用该表中的随机变化函数
    public delegate void OnShot();
    public OnShot onShot;
    private int nextBulletID = 0;
    private int bulletNumber;

    // Use this for initialization
    void Start () {
        bulletNumber = bullet.Length;
	}

    private bool canEmit()//判断是否还有能力发射子弹
    {
        return EmitRound <0 | EmitRound > 0; //for faster
    }

    private void Emit()
    {
        if (tracking)
        {
            transform.LookAt(Vector3.forward + gameObject.transform.position, DanmakuManager.instance.player.transform.position - gameObject.transform.position);
            //transform.LookAt(DanmakuManager.instance.player.transform);
        }
            
        for (int i = 0; i < EmitNumber; i++)
        {
            GameObject obj;
            obj = Instantiate(bullet[nextBulletID],transform.position,transform.rotation);
            obj.transform.Rotate(0,0,i * EmitAngle / EmitNumber - (EmitNumber - 1) * EmitAngle / (EmitNumber * 2));
            if(!worldSpace)obj.transform.parent = gameObject.transform;
            if (randomFunction != null)
                foreach (RandomFunction func in randomFunction)
                    func.Acting(obj);
        }
        onShot();
    }

    private void FixedUpdate()
    {
        if (!canEmit())
        {
            Destroy(gameObject);
            return;
        }
        startTime -= Time.deltaTime;
        if (startTime <= 0)
        {
            startTime = roundTime;
            EmitRound--;
            Emit();
            if (randomSelectBullet)
                nextBulletID = Random.Range(0,bulletNumber);
            else
                nextBulletID = (nextBulletID + 1) % bulletNumber;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
