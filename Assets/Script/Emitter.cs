using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomFunc
{
    float Rand();
}

public class RandomSphere : IRandomFunc
{
    public float Rand() { return 1; }
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
    public enum RandomFunction { a,b};
    public RandomFunction F;

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
        }

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
            nextBulletID = (nextBulletID + 1) % bulletNumber;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
