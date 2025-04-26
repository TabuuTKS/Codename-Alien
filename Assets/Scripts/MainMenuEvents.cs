using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    [SerializeField] GameObject StartUI, LevelSelectUI;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        StartUI.SetActive(false);
        LevelSelectUI.SetActive(true);
    }

    public void DemoLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackBTN()
    {
        StartUI.SetActive(true);
        LevelSelectUI.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            // Simulates quitting the game in the Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quits the application when built
            Application.Quit();
        #endif
    }
}
