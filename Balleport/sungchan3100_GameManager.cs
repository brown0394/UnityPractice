using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sungchan3100_GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public TextMeshProUGUI timeText;
    private int second = 0;
    private int minute = 0;
    private bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        startScreen.SetActive(false);
        isGameActive = true;
        player.SetActive(true);
        InvokeRepeating("TimeCount", 0.0f, 1.0f);
    }

    public void GameOver()
    {
        isGameActive = false;
        player.SetActive(false);
        CancelInvoke("TimeCount");
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TimeCount()
    {
        ++second;
        if (second == 60)
        {
            second = 0;
            ++minute;
        }
    }

    public void Win()
    {
        winScreen.SetActive(true);
        player.SetActive(false);
        timeText.text = "Time Count: " + minute + "m " + second + "s";
    }

    public bool IsGameActive() { return  isGameActive; }
}
