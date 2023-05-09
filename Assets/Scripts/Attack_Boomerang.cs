using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Boomerang : MonoBehaviour
{
    //transform del jugador
    private Transform tr;
    GameObject Boomerang_Prefab;
    GameObject Bmrg;


    public float moveSpeed = 0.03f;
    public float timeHeld = 0.0f;
    public float minHold = 1.0f;
    public float maxHold = 3.0f;

    private bool holding;
    private float startHeld = 0.0f;
    private bool countingTime = false;


    private int animationStage = 0;
    /*
        0 -> no está en la animación
        1 -> etapa 1 de la animación
        2 -> ''    2    ''
        3 -> ''    3    ''
        
    */

    private Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)};

    void Start()
    {
        tr = GetComponent<Transform>();
        Boomerang_Prefab = Resources.Load("Prefabs/Boomerang", typeof(GameObject)) as GameObject;
    }

    
    void Update()
    {
        //Solo se ejecuta si no está en la animación
        if(animationStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && !countingTime)
            {
                Debug.Log("Inicia el held");
                startHeld = Time.time;
                countingTime = true;
                holding = true;
            }
            if (countingTime)
            {
                timeHeld = Time.time - startHeld;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                holding = false;
            }
            if ((!holding && timeHeld>minHold) || timeHeld>maxHold)
            {
                Debug.Log("Inicia el ataque de boomerang");
                Bmrg = GameObject.Instantiate(Boomerang_Prefab);
                Bmrg.transform.SetParent(this.gameObject.transform);
                Bmrg.transform.rotation = tr.rotation;
                Bmrg.transform.position = tr.position;
                Bmrg.transform.position += Bmrg.transform.rotation * Vector3.forward * 1.0f;
                Bmrg.transform.RotateAround(tr.position, Vector3.up, 60);
                animationStage = 1;

                positionArray[0] = tr.position + (tr.rotation * (Vector3.forward + Vector3.right) * timeHeld * 3);
                positionArray[1] = tr.position + (tr.rotation * (Vector3.forward + Vector3.left) * timeHeld * 3);

                countingTime = false;
                timeHeld = 0.0f;
            }
        }
        else        //solo se ejecuta si está en la animación
        {
            Debug.Log("Animation stage:" + animationStage);
            positionArray[2] = tr.position;

            Bmrg.transform.position = Vector3.MoveTowards(Bmrg.transform.position, positionArray[animationStage - 1], moveSpeed);

            if (Bmrg.transform.position == positionArray[animationStage-1])
            {
                animationStage++;
                if (animationStage>3)
                {
                    animationStage = 0;
                    Destroy(Bmrg);
                }
            }

        }   

    }
}
