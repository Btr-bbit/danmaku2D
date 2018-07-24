using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StaticAudio : MonoBehaviour {
    AudioControl.MusicType type = AudioControl.MusicType.none;
    bool isPlayOver = true;
    AudioSource audioSource;
    const float offset = 0.2f;
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            throw new System.Exception("In StaticAudio,audioSource is null.");
        audioSource.volume = (1 - Random.Range(0f, offset)) * audioSource.volume;
        if (type != AudioControl.MusicType.none)
        {
            audioSource.clip = AudioControl.instance.ElementClips[(int)type];
            audioSource.Play();
        }
    }

    public void play(AudioControl.MusicType type_)
    {
        isPlayOver = false;
        type = type_;
        AudioControl.instance.MusicNum[(int)type]--;
        if (audioSource != null)
        {
            audioSource.clip = AudioControl.instance.ElementClips[(int)type];
            audioSource.Play();
        }
    }

	void Update () {
        if (isPlayOver == false && audioSource.isPlaying == false)
        {
            //播放完成
            AudioControl.instance.MusicNum[(int)type]++;
            GameObject.Destroy(gameObject);
        }
    }
}
