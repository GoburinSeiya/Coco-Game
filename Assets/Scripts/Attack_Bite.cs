using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Bite : MonoBehaviour
{
    //transform del jugador
    public Transform tr;
    GameObject HitboxPrefab;
    GameObject Hitbox;

    private float cooldown = 0.0f;
    private float start_time = 0.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        HitboxPrefab = Resources.Load("Prefabs/Bite", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > start_time+cooldown)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Hitbox = GameObject.Instantiate(HitboxPrefab);
                Hitbox.transform.position = tr.position;
                Hitbox.transform.rotation = tr.rotation;
                Hitbox.transform.position += Hitbox.transform.rotation * Vector3.forward * 2;
                Destroy(Hitbox, 0.2f);
                start_time = Time.time;
                cooldown = 1.7f;
            }
        }
        else 
        {
            Debug.Log("Trae cooldown la mordida");
        }
    }
}

