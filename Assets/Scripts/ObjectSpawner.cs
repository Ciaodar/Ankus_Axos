using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Oluşturulacak prefab
    public Transform parentContainer; // Oluşan objelerin parent'ı (düzen için)
    public int maxCount = 3; // Bu objeden en fazla kaç tane üretilebilir?
    private int currentCount = 0; // Şu ana kadar kaç tane üretildi?

    public GameManager gameManager; // GameManager bağlantısı

    public void SpawnObject()
    {
        // Eğer limit dolmuşsa yeni obje oluşturulmaz
        if (currentCount >= maxCount)
        {
            Debug.Log("Bu objeden daha fazla yerleştirilemez.");
            return;
        }

        // Prefab’ı oluştur
        GameObject obj = Instantiate(objectPrefab, parentContainer);

        // %50 saydamlık ver
        obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

        // Collider kapalı başlasın
        obj.GetComponent<BoxCollider2D>().enabled = false;

        // Mouse'u takip etsin
        obj.AddComponent<FollowMouse>();

        // GameManager’a kaydet
        gameManager.RegisterObject(obj.GetComponent<PlacedObject>());

        // Sayaç arttır
        currentCount++;
    }
}
