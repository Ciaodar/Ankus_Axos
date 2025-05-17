using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool isCarryingAxolotl = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axolotl") && !isCarryingAxolotl)
        {
            isCarryingAxolotl = true;
            Destroy(other.gameObject); // Ya da gizle
            // Belki karakterin üstünde bir sprite ile göster
        }

        if (other.CompareTag("Lake") && isCarryingAxolotl)
        {
            isCarryingAxolotl = false;
            FindObjectOfType<AxolotlManager>().RescueAxolotl();
        }
    }
}
