using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//对clip内的背景音乐随机播放，控制音效的数量
public class AudioControl : MonoBehaviour {

    static AudioControl _instance;
    static public AudioControl instance {
        get {
            return _instance;
        }
    }
    //音乐文件
    private AudioSource music;
    public float musicVolume
    {
        get { return music.volume; }
        set {
            music.volume = value;
        }
    }
    public AudioClip[] clip;//背景音乐集合
    private bool backGroundMusicMute = false;//是否静音
    public bool RandomSwitching = true;//一首音乐播放完后随机切换下一首
    bool isFirstMusic = true;
    public bool BackGroundMusicMute {
        get {
            return backGroundMusicMute;
        }
        set {
            if (value != backGroundMusicMute)
            {
                backGroundMusicMute = value;
                if (value == true)
                    music.Play();
                else music.Pause();
            }
        }
    }
    //全局音效,与AudioSubControl、StaticAudio共同使用
    public GameObject staticAudio;//静态音源预制体，仅含一个无多普勒的AudioSource
    public enum MusicType { none, heroBullet, enermyBullet, chooseHero, heroDie, heroDash, monsterDie, monsterShot, changeGun };
    [HideInInspector]
    public int[] MusicNum;//允许音效同时播放的个数
    [HideInInspector]
    public AudioClip[] ElementClips;//音效集合，在inspector中赋值
    [HideInInspector]
    public bool[] ElementClipLock = new bool[System.Enum.GetNames(typeof(AudioControl.MusicType)).Length];//音效锁，一帧只能播放一个音效

    void Start()
    {
        if (!gameObject.GetComponent<AudioSource>())
            throw new System.Exception("In AudioControl:AudioSource is not found.");
        music = gameObject.GetComponent<AudioSource>();

        if (_instance)
            throw new System.Exception("There are more than two AudioControl in the scene.");
        else _instance = this;
    }

    void PlayNewMusic()
    {
        Random.InitState(System.Environment.TickCount);
        if (clip.Length == 0) return;
        int id=Random.Range(0,clip.Length);
        music.clip = clip[id];
        music.Play();
    }

    public void setVolume(float val)
    {
        musicVolume = val;
    }

    void Update()
    {
        if (backGroundMusicMute == false && music.isPlaying == false)
            if(isFirstMusic==true || RandomSwitching)
            {
                PlayNewMusic();
            }
        //打开音效锁
        for (int i = 0; i < ElementClipLock.Length; i++)
            ElementClipLock[i] = false;
    }

}
