using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceObjectManager : MonoBehaviour
{
    // Şu an sahnede takip eden obje
    private GameObject currentGhostObject;

    // Yerleştirilecek prefab
    private GameObject selectedPrefab;

    public int placeCount = 1; // Kaç adet obje yerleştirileceğini belirler

    // Update fonksiyonu her frame çağrılır
    void Update()
    {
        // Eğer takip eden bir obje varsa mouse pozisyonunu takip ettir
        if (currentGhostObject != null && placeCount > 0)
        {
            // Mouse pozisyonunu ekran koordinatından dünya koordinatına çevir
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z eksenini sıfırla (2D oyun olduğu için)

            currentGhostObject.transform.position = mousePosition;

            // Sol tıklama yapıldıysa objeyi sabitle
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                PlaceObject();
            }
        }
    }

    // UI butonu üzerinden çağrılır, hangi prefab seçilecekse ismi gönderilir
    public void SelectObject(GameObject prefabName)
    {
        // Eğer yerleştirme hakkı yoksa hiçbir şey yapma
        if (placeCount <= 0)
            return;

        // Eğer sahnede bir önceki hayalet obje varsa sil
        if (currentGhostObject != null)
        {
            Destroy(currentGhostObject);
        }

        // Resources klasöründen prefabı yükle
        selectedPrefab = prefabName;

        if (selectedPrefab != null)
        {
            // Yeni bir kopya oluştur
            currentGhostObject = Instantiate(selectedPrefab);
            SetGhostMode(currentGhostObject, true); // Şeffaf ve collider kapalı
        }
        else
        {
            Debug.LogError("Prefab bulunamadı: " + prefabName);
        }
    }

    // Objeyi yerleştir, opak yap, collider aç
    private void PlaceObject()
    {
        SetGhostMode(currentGhostObject, false); // Normal moda geç

        // Süre atama panelini aç ve objeyi gönder
        ShowAssignTimePanel(currentGhostObject);

        currentGhostObject = null; // Takip durur
        placeCount--;
    }

    // Süre atama panelini açan fonksiyon (UI panelini siz oluşturmalısınız)
    private void ShowAssignTimePanel(GameObject obj)
    {
        // Prefabın içindeki AssignTimePanel scriptini bul ve aç
        AssignTimePanel panel = obj.GetComponentInChildren<AssignTimePanel>(true);
        if (panel != null)
        {
            panel.Open(obj);
        }
    }

    // Objeyi ghost (yarı saydam, collider kapalı) veya normal moda ayarlar
    private void SetGhostMode(GameObject obj, bool isGhost)
    {
        // Opaklık ayarla (SpriteRenderer üzerinden)
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = isGhost ? 0.5f : 1f;
            sr.color = color;
        }

        // Collider aktif/pasif ayarla
        Collider2D col = obj.GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = !isGhost;
        }
    }
}

