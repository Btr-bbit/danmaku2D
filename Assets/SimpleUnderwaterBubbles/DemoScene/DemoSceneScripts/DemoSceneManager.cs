using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSceneManager : MonoBehaviour {

    public ParticleSystem[] _particleEffects; //The list of all particle effects the scene can show

    private int _effectIndex = 0;

    void Start()
    {
        foreach(ParticleSystem system in _particleEffects) //Disable every particlesystem
        {
            system.gameObject.SetActive(false);
        }
        _particleEffects[_effectIndex].gameObject.SetActive(true);
    }

    /// <summary>
    /// Is emmitted whenever the next button in the Demo scene is pressed
    /// </summary>
    public void OnNextButtonPressed()
    {
        _particleEffects[_effectIndex].gameObject.SetActive(false); //Deactivate current particle effect
        _effectIndex++;
        if (_effectIndex > _particleEffects.Length - 1)  //When the effect index is above the last array index
        {
            _effectIndex = 0; //Set index to first element
        }
        _particleEffects[_effectIndex].gameObject.SetActive(true); //Activate next particle effect
    }

    /// <summary>
    /// Is emmitted whenever the prev button in the Demo scene is pressed
    /// </summary>
    public void OnPrevButtonPressed()
    {
        _particleEffects[_effectIndex].gameObject.SetActive(false); //Deactivate current particle effect
        _effectIndex--;
        if (_effectIndex < 0)  //When the effect index is less than the last array index
        {
            _effectIndex = _particleEffects.Length - 1; //set index to last element
        }
        _particleEffects[_effectIndex].gameObject.SetActive(true); //Activate next particle effect
    }
}
