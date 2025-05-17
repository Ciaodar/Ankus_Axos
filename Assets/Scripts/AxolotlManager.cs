using UnityEngine;
using UnityEngine.SceneManagement;

public class AxolotlManager : MonoBehaviour
{
    public int totalAxolotlsInLevel;
    public int rescuedAxolotls = 0;

    private LevelManager levelManager;

    void Start()
    {
        totalAxolotlsInLevel = GameObject.FindGameObjectsWithTag("Axolotl").Length;
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void RescueAxolotl()
    {
        rescuedAxolotls++;

        if (AllRescued())
        {
            ShowResultPanel(); // Direkt sahne geçme, panel göster
        }
    }

    public bool AllRescued()
    {
        return rescuedAxolotls == totalAxolotlsInLevel;
    }

    public void ShowResultPanel()
    {
        if (levelManager != null)
        {
            levelManager.ShowPanel();
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Son sahneydi, ana menüye dönülüyor veya oyun bitiyor.");
            SceneManager.LoadScene(0); // Ana menü ya da oyun sonu sahnesi
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}