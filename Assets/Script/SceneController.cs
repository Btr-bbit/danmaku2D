using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;
    public enum CurrentScene
    {
        init,
        title,
        pick,
        loading,
        game
    };
    public CurrentScene currentScene = CurrentScene.init;

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
        switch2Title();
    }

    public void switch2Pick()
    {
        Debug.Log("switch2Pick");
        StartCoroutine("Pick");
    }

    public void switch2Game()
    {
        Debug.Log("switch2Game");
        StartCoroutine("Game");
    }

    public void switch2Title()
    {
        Debug.Log("switch2Title");
        StartCoroutine("Title");
    }

    public void UnloadScene(CurrentScene unloadScene = CurrentScene.init) 
    {
        switch (unloadScene)
        {
            case CurrentScene.loading:
                if (SceneManager.GetSceneByName("Loading").IsValid() || SceneManager.GetSceneByName("Loading").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Loading");
                }
                break;
            case CurrentScene.pick:
                if (SceneManager.GetSceneByName("Pick").IsValid() || SceneManager.GetSceneByName("Pick").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Pick");
                }
                break;
            case CurrentScene.title:
                if (SceneManager.GetSceneByName("Title").IsValid() || SceneManager.GetSceneByName("Title").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Title");
                }
                break;
            case CurrentScene.game:
                if (SceneManager.GetSceneByName("Demo").IsValid() || SceneManager.GetSceneByName("Demo").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Demo");
                }
                break;
            default:
                if (SceneManager.GetSceneByName("Loading").IsValid() || SceneManager.GetSceneByName("Loading").isLoaded) {
                    SceneManager.UnloadSceneAsync("Loading");
                }
                if (SceneManager.GetSceneByName("Demo").IsValid() || SceneManager.GetSceneByName("Demo").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Demo");
                }
                if (SceneManager.GetSceneByName("Pick").IsValid() || SceneManager.GetSceneByName("Pick").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Pick");
                }
                if (SceneManager.GetSceneByName("Title").IsValid() || SceneManager.GetSceneByName("Title").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Title");
                }
                /*SceneManager.UnloadSceneAsync("Pick");
                SceneManager.UnloadSceneAsync("Title");
                SceneManager.UnloadSceneAsync("Demo");*/
                break;
        }
    }

    IEnumerator Pick()
    {
        UnloadScene();
        currentScene = CurrentScene.pick;
        SceneManager.LoadSceneAsync("Pick", LoadSceneMode.Additive);
        while (SceneManager.GetSceneByName("Pick").IsValid() == false || SceneManager.GetSceneByName("Pick").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Pick"));
    }

    IEnumerator Game()
    {
        UnloadScene();
        SceneManager.LoadSceneAsync("Demo", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        while (SceneManager.GetSceneByName("Loading").IsValid() == false || SceneManager.GetSceneByName("Loading").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Loading"));
        while (SceneManager.GetSceneByName("Loading").IsValid() == true || SceneManager.GetSceneByName("Loading").isLoaded == true)
        {
            yield return null;
        }
        while (SceneManager.GetSceneByName("Demo").IsValid() == false || SceneManager.GetSceneByName("Demo").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));

        /*currentScene = CurrentScene.game;
        SceneManager.LoadSceneAsync("Demo", LoadSceneMode.Additive);
        while (SceneManager.GetSceneByName("Demo").IsValid() == false || SceneManager.GetSceneByName("Demo").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));*/
    }

    IEnumerator Title()
    {
        UnloadScene();
        currentScene = CurrentScene.title;
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
        yield return new WaitUntil(() => (SceneManager.GetSceneByName("Title").isLoaded));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Title"));
    }
}
