using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI axolotlText;
    public TextMeshProUGUI timerText;
    public Button restartButton;
    public Button nextLevelButton;

    private AxolotlManager axolotlManager;
    private Timer timer;

    void Start()
    {
        axolotlManager = FindObjectOfType<AxolotlManager>();
        timer = FindObjectOfType<Timer>();

        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
    }

    void Update()
    {
        // Axolotl durumu
        axolotlText.text = $"Kurtarılan: {axolotlManager.rescuedAxolotls} / {axolotlManager.totalAxolotlsInLevel}";

        // Zamanı güncelle
        timerText.text = $"Kalan Süre: {Mathf.CeilToInt(timer.totalTime)}";

        // Tuş aktif mi?
        nextLevelButton.interactable = axolotlManager.rescuedAxolotls > 0;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextLevel()
    {
        if (axolotlManager.rescuedAxolotls > 0)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Son level.");
            }
        }
    }
}
