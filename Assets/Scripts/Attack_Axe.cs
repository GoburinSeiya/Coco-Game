using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Axe : MonoBehaviour
{ 
    //transform del jugador
    private Transform tr;
    GameObject Axe_Prefab;
    GameObject Axe;
    private bool inAnimation = false;

    private float start_time = 0.0f;
    public float attack_time = 0.35f; //0.35f
    private float time_attacking = 0.0f;

    private float cooldown = 0.0f;
    
    public float attackSpeed;
    void Start()
    {
        tr = GetComponent<Transform>();
        Axe_Prefab = Resources.Load("Prefabs/Axe", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > start_time + cooldown)
        {
            //se inicia el ataque
            if (Input.GetKey(KeyCode.W) && !inAnimation)
            {
                Debug.Log("Inicia el ataque");
                Axe = GameObject.Instantiate(Axe_Prefab);
                Axe.transform.SetParent(this.gameObject.transform);
                Axe.transform.rotation = tr.rotation;
                Axe.transform.position = tr.position;
                Axe.transform.position += Axe.transform.rotation * Vector3.forward * 2;
                Axe.transform.RotateAround(tr.position, Vector3.up, 60);
                inAnimation = true;
                start_time = Time.time;
            }
        }
        else
        {
            //indicador de que no puede atacar por cooldown
            Debug.Log("Está en cooldown el hacha");
        }
        

        if (inAnimation && time_attacking<attack_time)
        {
            cooldown = 4.0f;
            time_attacking = Time.time - start_time;
            Axe.transform.RotateAround(tr.position, Vector3.up, -45 * Time.deltaTime*attackSpeed);
        }
        else 
        { 
            inAnimation = false;
            time_attacking = 0;
            Destroy(Axe);
        } 


    }
}
