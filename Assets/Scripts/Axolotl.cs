using UnityEngine;

public class Axolotl : MonoBehaviour
{
    private bool hasBeenSaved = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Çarp??ma oldu: " + other.name);

        if (!hasBeenSaved && other.CompareTag("Lake"))
        {
            Debug.Log("Lake'e girdi!");
            hasBeenSaved = true;
            AxolotlManager.Instance.AxolotlSaved();
            Destroy(gameObject); // veya görünmez yap
        }
    }

}
