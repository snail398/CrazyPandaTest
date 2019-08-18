using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt(Saver.LOAD_FLAG, 0);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
        PlayerPrefs.SetInt(Saver.LOAD_FLAG, 1);
    }
}
