using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted = false;
    public PlayerController playerController;
    public Button[] placeObjectButtons;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        // Tüm aktif AssignTimePanel'leri bul
        var panels = FindObjectsOfType<AssignTimePanel>(true);
        foreach (var panel in panels)
        {
            // Eğer panel açıksa ve henüz onaylanmamışsa otomatik 0 ile onayla
            if (panel.gameObject.activeSelf)
            {
                panel.inputField.text = "0";
                panel.OnConfirm();
            }
        }

        isGameStarted = true;

        if (playerController != null)
        {
            playerController.enabled = true;
            playerController.gameObject.SetActive(true); // Karakteri görünür yap
        }

        foreach (var btn in placeObjectButtons)
        {
            btn.interactable = false;
        }
    }
}