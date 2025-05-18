using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip mainMenuMusic;
    public AudioClip introMusic;
    public AudioClip gameplayMusic;
    public AudioClip cutSceneMusic;
    public AudioClip secondActMusic;
    public AudioClip creditMusic;

    private string currentScene = "";

    void Awake()
    {
        // Scene değişimlerinde yok olmasın
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.name;
        PlayMusicForScene(currentScene);
    }

    void PlayMusicForScene(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch(sceneName)
        {
            case "MainMenu":
                clipToPlay = mainMenuMusic;
                break;
            case "IntroB":
                clipToPlay = introMusic;
                break;
            case "Level 1":
            case "Level 2":
            case "Level 3":
            case "Level 4 2":
                clipToPlay = gameplayMusic;
                break;
            case "IntroA":
                clipToPlay = cutSceneMusic;
                break;
            case "EdenLevels":
                clipToPlay = secondActMusic;
                break;
            case "CreditsX":
                clipToPlay = creditMusic;
                break;
            default:
                clipToPlay = null; // Müziği kapatabilirsin
                break;
        }

        if (clipToPlay != null && audioSource.clip != clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }
}
