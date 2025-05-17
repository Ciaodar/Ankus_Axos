using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameStarted = false;
    public PlayerController playerController;
    public Button[] placeObjectButtons;
    public Button playButton;
    public GameObject confirmPanel; // Inspector'dan ata
    public GameObject objectListPanel; // Inspector'dan ata

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        var panels = FindObjectsOfType<AssignTimePanel>(true);
        bool hasUnconfirmed = false;

        foreach (var panel in panels)
        {
            if (panel.gameObject.activeSelf && panel.inputPanel.activeSelf)
            {
                hasUnconfirmed = true;
                break;
            }
        }

        if (hasUnconfirmed)
        {
            if (confirmPanel != null)
                confirmPanel.SetActive(true);
            return; // Oyun başlamasın!
        }

        // Aşağısı: Tüm paneller onaylandıysa normal başlat
        foreach (var panel in panels)
        {
            float time = 0;
            if (float.TryParse(panel.inputField.text, out time) && time > 0)
            {
                panel.OnConfirm();
                panel.StartTimerPanel(time);
            }
            else
            {
                panel.inputField.text = "0";
                panel.OnConfirm();
                panel.StartTimerPanel(0);
            }
        }

        isGameStarted = true;

        if (playerController != null)
        {
            playerController.enabled = true;
            playerController.gameObject.SetActive(true);
        }

        foreach (var btn in placeObjectButtons)
        {
            btn.interactable = false;
        }

        if (playButton != null)
            playButton.gameObject.SetActive(false);

        // ObjectListPanel'i devre dışı bırak
        if (objectListPanel != null)
            objectListPanel.SetActive(false);

        if (Timer.Instance != null)
            Timer.Instance.StartTotalTimer();
    }

    public void ConfirmUnconfirmedPanels()
    {
        var panels = FindObjectsOfType<AssignTimePanel>(true);
        foreach (var panel in panels)
        {
            if (panel.gameObject.activeSelf && panel.inputPanel.activeSelf)
            {
                panel.inputField.text = "0";
                panel.OnConfirm();
                panel.StartTimerPanel(0);
            }
        }
        if (confirmPanel != null)
            confirmPanel.SetActive(false);

        StartGame(); // Şimdi oyunu başlat
    }

    public void CancelStartGame()
    {
        if (confirmPanel != null)
            confirmPanel.SetActive(false);
        // Oyun başlamaz, PlayButton açık kalır
    }
}