using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.LucidEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraDownloader : MonoBehaviour
{
    private CameraLook cam;
    public float speed = 5f; // Speed of the camera movement
    public Transform down; // low point
    public float waitDuration = 2f;
    public int nextScene;
     // Duration of the fade-in effect

    private void Start()
    {
        
        cam = FindObjectOfType<CameraLook>();
    }

    void Update()
    {
        if(cam.offset.y<down.position.y) {
            cam.offset.y=down.position.y; // Prevents the camera from moving downwards if it is already at the bottom
            enabled = false; // Disable this script
            StartCoroutine(FadeInNextScene()); // Start the fade-in coroutine
            return;
        }
        cam.offset.y -= speed * Time.deltaTime; // Move the camera downwards
    }
    
    //this coroutine is used to fade out and fade into the next scene after duration
    private IEnumerator FadeInNextScene()
    {
        // Fade in the next scene
        float elapsedTime = 0f;
        while (elapsedTime < waitDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
