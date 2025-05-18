using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.LucidEditor;
using TMPro;
using UnityEngine;

public class CameraDownloader : MonoBehaviour
{
    private CameraLook cam;
    public float speed = 5f; // Speed of the camera movement
    public Transform down; // low point

    [TitleHeader("Text Fade In Settings")]
    public TextMeshProUGUI text;
    public float fadeDuration = 2f; // Duration of the fade-in effect

    private void Start()
    {
        cam = FindObjectOfType<CameraLook>();
    }

    void Update()
    {
        if(cam.offset.y<down.position.y) {
            cam.offset.y=down.position.y; // Prevents the camera from moving downwards if it is already at the bottom
            enabled = false; // Disable this script
            StartCoroutine(FadeInText(text, fadeDuration)); // Start the fade-in coroutine
            return;
        }
        cam.offset.y -= speed * Time.deltaTime; // Move the camera downwards
    }
    
    //this coroutine is used to make a TextMeshProUGUI object fade in.
    private IEnumerator FadeInText(TextMeshProUGUI text, float duration)
    {
        Color color = text.color;
        color.a = 0; // Start with transparent text
        text.color = color;

        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / duration); // Fade in the text
            text.color = color;
            yield return null;
        }
    }
}
