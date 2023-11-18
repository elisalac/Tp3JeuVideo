using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementComponent : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float distance = 5f; // The distance between the camera and the target
    [SerializeField] float rotationSpeed = 5f; // The speed of camera rotation

    private Vector3 offset; // The offset between the camera and the target

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - player.position;
    }

    private void Update()
    {
        // Get the mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the camera around the target based on the mouse movement
        //transform.RotateAround(player.position, Vector3.up, mouseX * rotationSpeed * Time.deltaTime);

        // Calculate the new position of the camera based on the rotation and distance
        Vector3 newPosition = player.position + (offset.normalized * distance);

        // Move the camera to the new position
        transform.position = newPosition;

        // Make the camera look at the target
        transform.LookAt(player);
    }
}
