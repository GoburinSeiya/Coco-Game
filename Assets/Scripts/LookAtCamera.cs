using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Transform cameraTransform = Camera.main.transform;
        //transform.LookAt(cameraTransform);
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
