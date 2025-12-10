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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource musicSource; // Müziği çalan kaynak
    [SerializeField] private AudioSource sfxSource;   // Efektleri çalan kaynak
    [SerializeField] private AudioClip scoreClip;     // Puan alma sesi dosyası

    private int score = 0;
    public static bool autoStart = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Oyun başladığında müzik çalmıyorsa başlat (Emin olmak için)
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
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
            scoreText.gameObject.SetActive(false);
        }
    }

    public void PlayGame()
    {
        autoStart = false;
        score = 0;
        scoreText.text = "0";

        startScreenCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        scoreText.gameObject.SetActive(true);

        Time.timeScale = 1f;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        // YENİ: Skor sesini çal (PlayOneShot, üst üste çalabilmeyi sağlar)
        sfxSource.PlayOneShot(scoreClip);
    }

    public void GameOver()
    {
        // YENİ: Müziği durdur
        musicSource.Stop();

        scoreText.gameObject.SetActive(false);
        finalScoreText.text = score.ToString();

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