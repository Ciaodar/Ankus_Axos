using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueManager : MonoBehaviour
{
    // Static variable to keep track of the number of axolotls saved.
    public GameObject[] statues; // Array of statue GameObjects.

    public void Start()
    {
        int axolotlCount=PlayerPrefs.GetInt("totalRescuedAxolotls", 7); // Get the number of axolotls saved from PlayerPrefs.
        for (int i=0; i<(axolotlCount>6?4:axolotlCount>5?3:axolotlCount>4?2:axolotlCount>3?1:0); i++)
        {
            statues[i].SetActive(true); // Activate all statues.
        }
    }
}
