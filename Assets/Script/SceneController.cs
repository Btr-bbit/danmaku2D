using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;
    enum CurrentScene
    {
        init,
        Title,
        pick,
        loading,
        game
    };
    CurrentScene currentScene = CurrentScene.init;

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

    private void UnloadCurrentScene() 
    {
        switch (currentScene)
        {
            case CurrentScene.loading:
                break;
            case CurrentScene.pick:
                break;
            case CurrentScene.Title:
                SceneManager.UnloadSceneAsync("Title");
                break;
            case CurrentScene.game:
                break;
            default:
                break;
        }
    }

    IEnumerator Game()
    {
        UnloadCurrentScene();
        currentScene = CurrentScene.game;
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        while (SceneManager.GetSceneByName("Game").IsValid() == false || SceneManager.GetSceneByName("Game").isLoaded == false)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }

    IEnumerator Title()
    {
        UnloadCurrentScene();
        currentScene = CurrentScene.Title;
        SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
        yield return new WaitUntil(() => (SceneManager.GetSceneByName("Title").isLoaded));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Title"));
    }
}
