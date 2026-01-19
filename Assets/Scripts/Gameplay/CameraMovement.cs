using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target; // Target for the camera to follow
    private void LateUpdate() 
    { 
        if (target != null) 
        {
            Vector3 newPosition = target.position; // Get the target's position
            newPosition.z = transform.position.z; // Maintain camera's Z position
            transform.position = newPosition; // Update camera position
        }
    }
}
