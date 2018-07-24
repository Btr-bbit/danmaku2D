using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public GameObject winPanel, losePanel;
    public static GameEventManager instance = null;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        //Win();
    }

    void Win()
    {
        winPanel.SetActive(true);
    }

    void Lose()
    {
        losePanel.SetActive(true);
    }
}
