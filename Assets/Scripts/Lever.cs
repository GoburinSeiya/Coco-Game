using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IDamageable
{
    public bool Activated;
    public Transform shaft;
    private Transform tr;
    
    void Start()
    {
        tr = GetComponent<Transform>();
        shaft.RotateAround(tr.position, Vector3.right, 30);
    }

    public void TakeDamage(int _value)
    {
        if (!Activated)
        {
            shaft.RotateAround(tr.position, Vector3.right, -60);
        }
        Activated = true;
        
    }
}
