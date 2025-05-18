using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool isCarryingAxolotl = false;
    public Transform efektPozisyonu;
    public GameObject kalpEfektiPrefab;
    public AxolotlManager axolotlManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axolotl") && !isCarryingAxolotl)
        {
            isCarryingAxolotl = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Lake") && isCarryingAxolotl)
        {
            isCarryingAxolotl = false;
            axolotlManager.RescueAxolotl();

            // Kalp efekti instantiate edilir
            Instantiate(kalpEfektiPrefab, efektPozisyonu.position, Quaternion.identity);

            // Level tamamlanma kontrolü ve panel açma
            axolotlManager.TryCompleteLevelWithLake();
        }
    }

}
