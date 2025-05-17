using UnityEngine;
using UnityEngine.SceneManagement;

public class AxolotlManager : MonoBehaviour
{
    public int totalAxolotls = 0; // Bu leveldeki toplam axolotl say?s?
    private int savedAxolotls = 0;

    public static AxolotlManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        // Otomatik say?m (iste?e ba?l?)
        totalAxolotls = GameObject.FindGameObjectsWithTag("Axolotl").Length;
    }

    public void AxolotlSaved()
    {
        savedAxolotls++;

        if (savedAxolotls >= totalAxolotls)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("Son level tamamland?. Ana menüye dönülüyor.");
            SceneManager.LoadScene(0); // Ana menü veya biti? sahnesi
        }
    }
}
