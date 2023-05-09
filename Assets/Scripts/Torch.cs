using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IDamageable
{
    private Transform tr;
    GameObject cube;
    public bool lit = false;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    public void TakeDamage(int _value) 
    {
        if (!lit)
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(this.gameObject.transform);
            cube.transform.localScale = new Vector3(0.75f, 0.3525f, 0.75f);
            cube.transform.position = tr.position + new Vector3(0.0f, 0.6f, 0.0f);
            lit = true;
        }
    }
}
