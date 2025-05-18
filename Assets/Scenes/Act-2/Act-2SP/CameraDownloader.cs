using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDownloader : MonoBehaviour
{
    private CameraLook cam;
    public float speed = 5f; // Speed of the camera movement
    public Transform down; // low point

    private void Start()
    {
        cam = FindObjectOfType<CameraLook>();
    }

    void Update()
    {
        if(cam.offset.y<down.position.y) {
            cam.offset.y=down.position.y; // Prevents the camera from moving downwards if it is already at the bottom
            enabled = false; // Disable this script
            return;
        }
        cam.offset.y -= speed * Time.deltaTime; // Move the camera downwards
    }
}
