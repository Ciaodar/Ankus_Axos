using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // This script is used to make the camera smoothly follow the player
    
    
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Speed of the camera's movement
    public Vector3 offset; // Offset from the player's position
    
    void Start()
    {
        // Initialize the camera's position
        transform.position = player.position + offset;
    }
    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = player.position + offset;
        
        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Update the camera's position
        transform.position = smoothedPosition;
    }
    
    
}
