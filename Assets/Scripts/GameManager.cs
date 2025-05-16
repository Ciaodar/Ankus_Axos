using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float totalTime = 100f; // Toplam süre (başlangıç)
    public Text totalTimeText; // UI'da gösterilecek yazı

    private List<PlacedObject> allObjects = new List<PlacedObject>(); // Tüm yerleştirilen objeler

    // Yeni bir obje yerleştirildiğinde listeye eklenir
    public void RegisterObject(PlacedObject obj)
    {
        allObjects.Add(obj);
    }

    public void StartGame()
    {
        float usedTime = 0f; // Toplam atanan süre

        // Tüm objelerden süreleri al
        foreach (var obj in allObjects)
        {
            float objTime = obj.GetAssignedTime();
            usedTime += objTime;
        }

        // Eğer verilen toplam süre, kalan süreden fazlaysa uyar
        if (usedTime > totalTime)
        {
            Debug.LogWarning("Toplam süre aşıldı!");
            return;
        }

        // Kalan toplam süreyi güncelle ve UI'da göster
        totalTime -= usedTime;
        UpdateTotalTimeUI();

        // Tüm objelerin sayaçlarını başlat
        foreach (var obj in allObjects)
        {
            obj.StartTimer();
        }
    }

    private void UpdateTotalTimeUI()
    {
        // Kalan toplam süreyi kullanıcıya göster
        if (totalTimeText != null)
            totalTimeText.text = "Kalan Süre: " + Mathf.RoundToInt(totalTime).ToString() + " sn";
    }
}
