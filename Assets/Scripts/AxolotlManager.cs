using UnityEngine;
using UnityEngine.SceneManagement;

public class AxolotlManager : MonoBehaviour
{
    public int totalAxolotlsInLevel;
    public int rescuedAxolotls = 0;

    
    private void Start()
    {
        // Otomatik say?m (iste?e ba?l?)
        totalAxolotlsInLevel = GameObject.FindGameObjectsWithTag("Axolotl").Length;
    }
    public void RescueAxolotl()
    {
        rescuedAxolotls++;
        if (AllRescued())
        {
            LoadNextScene();
        }
    }

    public bool AllRescued()
    {
        return rescuedAxolotls == totalAxolotlsInLevel;
    }
    
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Build ayarlarında bu sahne var mı kontrolü
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Son sahneydi, ana menüye dönülüyor veya oyun bitiyor.");
            SceneManager.LoadScene(0); // Alternatif olarak bir ana menü sahnesi
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}