using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    inputManager InputManager;

    public Transform targetTransform; //Objeto que sigue la camara
    public Transform cameraPivotTransform; //Pivote
    private Vector3 cameraFollowVelocity = Vector3.zero;

    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2; 
    // public float cameraPivotSpeed = 2; // Pseudocódigo por si ya no es isometrico, eje y
    public float lookAngle;  
    // public float pivotAngle; // Pseudocódigo por si ya no es isometrico, eje y
    // public float minimumPivotAngle = -35;
    // public float maximumPivotAngle = 35;

    public void Awake()
    {
        InputManager = FindObjectOfType<inputManager>();
        targetTransform = FindObjectOfType<playerManager>().transform;
    }


    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, 
            targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        lookAngle = lookAngle + (InputManager.cameraInputX * cameraLookSpeed);
        // pivotAngle = pivotAngle - (InputManager.cameraInputY * cameraPivotSpeed);
        //pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        /*
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivotTransform.localRotation = targetRotation;
        */ // Pseudocódigo por si ya no es isometrico, eje y
    }

}
