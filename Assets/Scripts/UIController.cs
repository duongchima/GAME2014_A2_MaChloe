using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIController : MonoBehaviour
{
    PlayerBehaviour player;
    TextMeshProUGUI scoreText;
    [SerializeField] GameObject pauseScreen, gameOverScreen;
    [SerializeField] TextMeshProUGUI finalScore;
    bool gameOver = false;
    bool gameIsPaused = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            int distance = Mathf.FloorToInt(player.distance);
            scoreText.text = distance.ToString();
        }
    }
    public void PlayerDeath()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        finalScore.text = Mathf.FloorToInt(player.distance).ToString();
        scoreText.gameObject.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        gameIsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        gameIsPaused = false;
    }

    public void Restart()
    {
        gameOver = false;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
