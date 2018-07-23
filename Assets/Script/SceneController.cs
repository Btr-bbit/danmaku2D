using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public delegate void CallWhenSwitchToType();

    CallWhenSwitchToType Switch2PlayingHandle, Switch2MenuHandle;
    public static SceneController instance = null;
    int currScene = -1;

    // Use this for initialization
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
        switch2menu();
    }

    public void switch2playing()
    {
        Debug.Log("switch2playing");
        StartCoroutine("playing");

    }

    public void switch2menu()
    {
        Debug.Log("switch2mainmenu");
        StartCoroutine("menu");
    }

    IEnumerator playing()
    {
        if (currScene == 1)
        {
            SceneManager.UnloadSceneAsync("menu");
        }
        currScene = 0; //scene: playing
        SceneManager.LoadSceneAsync("playing", LoadSceneMode.Additive);
        while (SceneManager.GetSceneByName("playing").IsValid() == false || SceneManager.GetSceneByName("playing").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("playing"));
    }

    IEnumerator menu()
    {
        if (currScene == 0)
        {
            SceneManager.UnloadSceneAsync("playing");
        }
        currScene = 1;//scene: menu
        SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);

        yield return new WaitUntil(() => (SceneManager.GetSceneByName("menu").isLoaded));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("menu"));
    }
}
