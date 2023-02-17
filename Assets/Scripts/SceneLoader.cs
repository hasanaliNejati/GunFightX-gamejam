using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public static void MainScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
