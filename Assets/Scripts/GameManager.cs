
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalCoins = 6;
    public static GameManager Instance;

    public TMP_Text coinText;
    public GameObject winPanel;

    private int coins = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coins + " / " + totalCoins;
    }

    public void LevelComplete()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}

