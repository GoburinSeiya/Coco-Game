using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IDamageable
{
    private Transform tr;
    GameObject cube;
    GameObject Flame_Prefab;
    GameObject Flame;
    public bool lit = false;
    void Start()
    {
        tr = GetComponent<Transform>();
        Flame_Prefab = Resources.Load("Prefabs/Parent_Fire", typeof(GameObject)) as GameObject;
    }
    public void TakeDamage(int _value) 
    {
        if (!lit)
        {
            Flame = GameObject.Instantiate(Flame_Prefab);
            Flame.transform.SetParent(this.gameObject.transform);
            Flame.transform.localScale = new Vector3(0.75f, 0.3525f, 0.75f);
            Flame.transform.position = tr.position + new Vector3(0.0f, 0.6f, 0.0f);
            lit = true;
        }
    }
}
