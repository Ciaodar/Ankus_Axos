using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatTriger : MonoBehaviour
{
    // This script is used to open the UI that says you entered the %floorNumber%. floor
    public int floorNumber = 1;
    public GameObject uiPanel; // Reference to the UI panel to show
    private GameObject player; 
    
    private void Start()
    {
        // Find the player GameObject in the scene
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject==player)
        {
            // Show the UI panel
            uiPanel.SetActive(true);
            Destroy(player);
        }
    }
}
