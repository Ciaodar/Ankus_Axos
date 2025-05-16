using UnityEngine;
using UnityEngine.UI;

public class PlacedObject : MonoBehaviour
{
    public InputField timeInput; // Süre girişi yapılacak alan
    private float countdown = -1f; // Geri sayım değeri
    private bool isTimerRunning = false; // Sayaç başlatıldı mı?

    public void ActivateObject()
    {
        // Opaklığı tam yap
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        // Collider zaten açılmış olacak (FollowMouse'da)
    }

    public void StartTimer()
    {
        // Kullanıcının girdiği süreyi al
        if (float.TryParse(timeInput.text, out float time))
        {
            countdown = time; // geri sayımı başlat
            isTimerRunning = true;
            timeInput.interactable = false; // tekrar yazılamasın
        }
        else
        {
            Debug.LogWarning("Geçersiz süre girişi!"); // Kullanıcı sayı girmezse uyar
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            countdown -= Time.deltaTime; // Zamanı azalt

            // Süre bittiğinde objeyi sahneden kaldır
            if (countdown <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public float GetAssignedTime()
    {
        // Bu obje için girilen süreyi al
        if (float.TryParse(timeInput.text, out float time))
            return time;
        return 0f;
    }
}
