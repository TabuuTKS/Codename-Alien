using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{

    public int PH3_Percentage = 100;
    public int coins = 0;
    public TMP_Text PH3_PercentLabel, CoinsLabel;
    public bool GameOver = false;
    public bool win = false;
    [SerializeField] GameObject GameOverUI, GameUI, WinUI;
    Player player;
    [SerializeField] AudioSource BGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PH3Breathing());
        GameOverUI.SetActive(GameOver);
        GameUI.SetActive(!GameOver);
        WinUI.SetActive(win);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PH3_Percentage == 0)
        {
            GameOver = true;
        }
        PH3_PercentLabel.text = PH3_Percentage + "%";
        CoinsLabel.text = coins + "%";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        #if UNITY_EDITOR
            // Simulates quitting the game in the Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Quits the application when built
            Application.Quit();
        #endif
    }
    IEnumerator PH3Breathing()
    {
        while (!GameOver && PH3_Percentage != 0)
        {
            yield return new WaitForSeconds(5);
            PH3_Percentage--;
            if (win)
            {
                WinUI.SetActive(win);
                BGM.Stop();
                break;
            }
        }
        if (GameOver)
        {
            player.Dead();
            BGM.Stop();
            GameOverUI.SetActive(GameOver);
            GameUI.SetActive(!GameOver);
        }
    }
}
