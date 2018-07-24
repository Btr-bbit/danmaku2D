using UnityEngine;
using System.Collections;

//将该脚本挂在GameObject上，作为全局音频控制的子控件在实例化时播放音频
public class AudioSubControl : MonoBehaviour {

    public AudioControl.MusicType type;//该音频所属类别
    public float RandomRate;//随机播放概率

    void Reset()
    {
        RandomRate = 1f;
    }

    bool canPlay()
    {
        //Debug.Log(string.Format("canPlay: type:{0} MusicNum:{1}", type.ToString(), AudioControl.instance.MusicNum[(int)type].ToString()));
        if (AudioControl.instance.MusicNum[(int)type] > 0)
            if (AudioControl.instance.ElementClipLock[(int)type] == false)
                if (Random.Range(0f,1f)<RandomRate)
                return true;
        return false;
    }

    void playMusic()
    {
        AudioControl.instance.ElementClipLock[(int)type] = true;
        GameObject staticAudio = Instantiate(AudioControl.instance.staticAudio,gameObject.transform.position,gameObject.transform.rotation) as GameObject;
        staticAudio.GetComponent<StaticAudio>().play(type);
    }

    void playOver()
    {
        AudioControl.instance.MusicNum[(int)type]++;
    }

	void Start () {
        if (canPlay())
            playMusic();
    }
}
