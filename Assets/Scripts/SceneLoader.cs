using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader scene_Instance;
    public static SceneLoader SceneInstance { get { return scene_Instance; } }

    private const string LOGIN_REG_SCENE = "LoginRegister";
    private const string LOAD_GAMES_SCENE = "LoadGames";
    private const string GAME_SCENE = "SampleScene";

    private void Awake()
    {
        if (scene_Instance == null)
        {
            scene_Instance = new SceneLoader();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void GoToLevel(string sceneName)
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        SceneManager.LoadScene(sceneName);
    }

    private void LoadLevelAsync(string sceneName, int size, int colors)
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadOperation.completed += (AsyncOperation result) =>
        {
            UnloadSelectedSceneAsync(LOAD_GAMES_SCENE);
            NewGrid.Instance.GenerateGame(size, colors);
        };
    }

    private void UnloadSelectedSceneAsync(string sceneName)
    {
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        unloadOperation.completed += (AsyncOperation result) =>
        {
            print("Scene: " + sceneName + " unloaded succsessfully");
        };
    }

    internal void StartGame(GameInformation gameInfo)
    {
        GameData.Instance.gameData = gameInfo;
        LoadLevelAsync(GAME_SCENE, gameInfo.size, gameInfo.colors);
    }
}