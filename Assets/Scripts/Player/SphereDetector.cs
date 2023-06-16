using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDetector : MonoBehaviour
{
    public float radius = 3f; // Radio de la esfera de detección
    public GameObject[] objectArray;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Debug.Log(other.gameObject.layer);
        }
    }
}

