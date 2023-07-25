using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IDamageable
{
    private Transform tr;
    GameObject Broken;
    GameObject Broken_Prefab;
    GameObject HP_Prefab;
    public bool lit = false;
    private int hp = 10;
    void Start()
    {
        
        tr = GetComponent<Transform>();
        Broken_Prefab = Resources.Load("Prefabs/Broken_Chest", typeof(GameObject)) as GameObject;
        HP_Prefab = Resources.Load("Prefabs/Health_Pickup", typeof(GameObject)) as GameObject;
    }
    public void TakeDamage(int _value)
    {
        hp = hp - _value;
        if(hp<=0)
        {
            Debug.Log("AAA ya lo rompiste");

            int hp_count = Random.Range(2, 4);
            GameObject[] HP = new GameObject[hp_count];
            for (int i=0; i<hp_count; i++)
            {
                HP[i] = GameObject.Instantiate(HP_Prefab);
                HP[i].transform.position = tr.position+(Vector3.up);
            }

            Broken = GameObject.Instantiate(Broken_Prefab);
            Broken.transform.position = tr.position;
            Broken.transform.rotation = tr.rotation;
            Destroy(this.gameObject);
        }
        

        
    }
}
