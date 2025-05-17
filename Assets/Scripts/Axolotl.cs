using UnityEngine;

public class Axolotl : MonoBehaviour
{
    private bool hasBeenSaved = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBeenSaved && other.CompareTag("Lake"))
        {
            hasBeenSaved = true;
            AxolotlManager.Instance.AxolotlSaved();
            Destroy(gameObject); // veya görünmez yap
        }
    }
}
