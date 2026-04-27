using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{ 
    public static LogicScript Instance { get; private set; }
    private int playerScore = 0;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text scoreText;

    // 2. Awake wird ganz am Anfang aufgerufen, noch vor Start()
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;

        }
    }

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        this.playerScore++;
        scoreText.text = "Score: " + this.playerScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
