using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEvents : MonoBehaviour
{

    public int PH3_Percentage = 100;
    public TMP_Text PH3_PercentLabel, CoinsLabel, KeyLabel;
    bool stopPH3 = false;
    [SerializeField] GameObject GameOverUI, GameUI, WinUI, PauseUI, KeyUI, MobileUI, DailogueUI;
    Player player;
    [SerializeField] AudioSource BGM;

    public bool MobilePort = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // make sure that game isn't paused while switching scenes
        Time.timeScale = 1;
        PlayerPrefs.coins = 0;
        StartCoroutine(PH3Breathing());
        GameOverUI.SetActive(false);
        GameUI.SetActive(true);
        WinUI.SetActive(false);
        PauseUI.SetActive(false);
        KeyUI.SetActive(false);
        MobileUI.SetActive(MobilePort);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P) && !GameOverUI.activeSelf && !WinUI.activeSelf)
        {
            PauseGame();
        }

        if (PH3_Percentage <= 0)
        {
            PH3_Percentage = 0;
            StopCoroutine(PH3Breathing());
            GameOver();
        }
        UpdateUI();
        MobileUIUpdate();
    }

    private void UpdateUI() {
        PH3_PercentLabel.text = PH3_Percentage + "%";
        CoinsLabel.text = PlayerPrefs.coins + "%";
        if (PlayerPrefs.keys > 0)
        {
            KeyUI.SetActive(true);
            KeyLabel.text = $"{PlayerPrefs.keys}";
        }
        else {
            KeyUI.SetActive(false);
        }
    }

    private void MobileUIUpdate() {
        if (MobilePort)
        {
            if (PauseUI.activeSelf || DailogueUI.activeSelf || WinUI.activeSelf)
            {
                MobileUI.SetActive(false);
            }
            else {
                MobileUI.SetActive(true);
            }
        }
        else {
            MobileUI.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        stopPH3 = true;
        player.Dead();
        BGM.Stop();
        GameOverUI.SetActive(true);
        GameUI.SetActive(false);
    }

    public void PauseGame()
    {
        BGM.Pause();
        PauseUI.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        BGM.Play();
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void Win()
    {
        stopPH3 = true;
        player.DisableMovements();
        WinUI.SetActive(true);
        GameUI.SetActive(false);
        BGM.Stop();
    }
    IEnumerator PH3Breathing()
    {
        while(PH3_Percentage > 0 && !stopPH3)
        {
            yield return new WaitForSeconds(5);
            PH3_Percentage--;
        }
    }
}
