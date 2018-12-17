using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    static public UIManager instance;
    [SerializeField]
    RectTransform blueEnergyMask, yellowEnergyMask;
    float maskMaxWeight;
    public GameObject HpIcon1,HpIcon0;
    public GameObject LifePanel;
    // Use this for initialization
    void Start() {
        if (instance == null)
            instance = this;
        else {Destroy(this); return; }
        maskMaxWeight = blueEnergyMask.sizeDelta.x;

    }

    void UpdateHP()
    {
        foreach (Transform obj in LifePanel.transform)
        {
            GameObject.Destroy(obj.gameObject);
        }

        for (int i = 0; i < PlayerState.HP; i++)
            GameObject.Instantiate(HpIcon1, LifePanel.transform);
        for (int i = PlayerState.HP; i < PlayerState.MaxHP; i++)
            GameObject.Instantiate(HpIcon0, LifePanel.transform);
    }

    void UpdateEnergy()
    {
        blueEnergyMask.sizeDelta = new Vector2(maskMaxWeight * PlayerState.blueEnergy / PlayerState.maxBlueEnergy, blueEnergyMask.sizeDelta.y);
        yellowEnergyMask.sizeDelta = new Vector2(maskMaxWeight * PlayerState.yellowEnergy / PlayerState.maxYellowEnergy, yellowEnergyMask.sizeDelta.y);
    }

	// Update is called once per frame
	void Update ()
    {
        UpdateHP();
        UpdateEnergy();
    }
}
