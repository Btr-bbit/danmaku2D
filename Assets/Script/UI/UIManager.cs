using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    RectTransform blueEnergyMask, yellowEnergyMask;
    float maskMaxWeight;

	// Use this for initialization
	void Start () {
        maskMaxWeight = blueEnergyMask.sizeDelta.x;

    }

    void UpdateEnergy()
    {
        blueEnergyMask.sizeDelta = new Vector2(maskMaxWeight * PlayerState.blueEnergy / PlayerState.maxBlueEnergy, blueEnergyMask.sizeDelta.y);
        yellowEnergyMask.sizeDelta = new Vector2(maskMaxWeight * PlayerState.yellowEnergy / PlayerState.maxYellowEnergy, yellowEnergyMask.sizeDelta.y);
    }

	// Update is called once per frame
	void Update () {
        UpdateEnergy();

    }
}
