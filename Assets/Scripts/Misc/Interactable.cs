using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 0.6f;
    public string interactableText;

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact(playerManager PlayerManager)
    {
        //Lo llamamos al interactuar
        Debug.Log("Interactuaste con un objeto");
    }
}
