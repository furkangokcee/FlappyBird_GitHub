using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Objects")]
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject startScreenCanvas;
    
    [Header("Score Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;      // Sağ üstteki (Oyun içi)
    [SerializeField] private TextMeshProUGUI finalScoreText; // YENİ: Paneldeki (Oyun sonu)

    private int score = 0;
    public static bool autoStart = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 0f;

        if (autoStart)
        {
            PlayGame();
        }
        else
        {
            startScreenCanvas.SetActive(true);
            gameOverCanvas.SetActive(false);
            scoreText.gameObject.SetActive(false); // Giriş ekranında skoru gizle
        }
    }

    public void PlayGame()
    {
        autoStart = false;
        score = 0;
        scoreText.text = "0";

        startScreenCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        
        scoreText.gameObject.SetActive(true); // YENİ: Oyun başlayınca sağ üstü aç
        
        Time.timeScale = 1f;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        // 1. Sağ üstteki skoru gizle
        scoreText.gameObject.SetActive(false);

        // 2. Paneldeki büyük skora puanı yaz
        finalScoreText.text = score.ToString();

        // 3. Paneli aç ve oyunu durdur
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        autoStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        autoStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}