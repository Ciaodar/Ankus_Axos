using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private bool isPlaced = false; // Obje yerleştirildi mi?

    void Update()
    {
        // Obje henüz yerleştirilmediyse
        if (!isPlaced)
        {
            // Mouse pozisyonunu dünya koordinatına çevir
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // z ekseni sabit (2D olduğu için)
            transform.position = mousePos; // objeyi mouse'un olduğu yere taşı

            // Eğer sol tıklama yapıldıysa
            if (Input.GetMouseButtonDown(0))
            {
                isPlaced = true; // artık yerleştirildi
                GetComponent<BoxCollider2D>().enabled = true; // collider aktif hale gelir
                GetComponent<PlacedObject>().ActivateObject(); // diğer ayarları yap
                Destroy(this); // bu script artık gerekmediği için silinir
            }
        }
    }
}
