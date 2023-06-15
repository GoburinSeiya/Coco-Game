using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    Rigidbody rb;
    AnimationManager animationManager;
    playerManager PlayerManager;
    inputManager InputManager;
    public Transform tr;
    private bool inAnimation = false;
    

    #region Variables Mordida
    GameObject HitboxPrefab;
    GameObject Hitbox;
    private float cooldownBite = 0.0f;
    private float start_time = 0.0f;
    #endregion
    /*
    #region Variables Boomerang
    GameObject Boomerang_Prefab;
    public Transform boomerangSpawnTransform;
    GameObject Bmrg;
    public float moveSpeed = 0.03f;
    public float minHold = 1.0f;
    public float maxHold = 3.0f;
    private bool countingTime = false;
    private bool holding;
    private int animationStage = 0;
     private Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)};
    #endregion
    */

    private void Awake() 
    {
        PlayerManager = GetComponent<playerManager>();
        animationManager = GetComponentInChildren<AnimationManager>();
        PlayerManager = GetComponent<playerManager>();
        InputManager = GetComponent<inputManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        HitboxPrefab = Resources.Load("Prefabs/Bite", typeof(GameObject)) as GameObject;
        //Boomerang_Prefab = Resources.Load("Prefabs/Boomerang", typeof(GameObject)) as GameObject;
    }

    public void HandleBiteAttack()
    {
        if(PlayerManager.isInteracting)
            return;
            
        else if(Time.time > start_time+cooldownBite)
        {
            rb.velocity = Vector3.zero;
            Hitbox = GameObject.Instantiate(HitboxPrefab);
            Hitbox.transform.position = tr.position;
            Hitbox.transform.rotation = tr.rotation;
            Hitbox.transform.position += Hitbox.transform.rotation * Vector3.forward * 2;
            Destroy(Hitbox, 0.2f);
            start_time = Time.time;
            cooldownBite = 1.7f;
        }
    }

    public void HandleAxeAttack(WeaponItem weapon)
    {
        if (PlayerManager.isInteracting)
            return;
        rb.velocity = Vector3.zero;
        animationManager.PlayTargetAniamtion(weapon.weaponLightAnimation, true);
    }

    //HandleHeavyAttack

    public void HandleTorchAttack(WeaponItem weapon)
    {
        if(PlayerManager.isInteracting)
            return;
        rb.velocity = Vector3.zero;
        animationManager.PlayTargetAniamtion(weapon.weaponLightAnimation, true);
    }

    public void StartTimeCounter(float startHeld)
    {
        Debug.Log("Inicia el held");
        startHeld = Time.time;
    }

    /*
    public void HandleBoomerangAttack(WeaponItem weapon, float heldTime, float startHeld)
    {
        if(PlayerManager.isInteracting)
            return;
        rb.velocity = Vector3.zero;
        
        StopTimeCounter(heldTime, startHeld);

        if(animationStage == 0)
        {
            if ((!holding && heldTime>minHold) || heldTime>maxHold)
            {
                Debug.Log("Inicia el ataque de boomerang");
                Bmrg = GameObject.Instantiate(Boomerang_Prefab);
                Bmrg.transform.SetParent(this.gameObject.transform);
                Bmrg.transform.rotation = boomerangSpawnTransform.rotation;
                Bmrg.transform.position = boomerangSpawnTransform.position;
                Bmrg.transform.position += Bmrg.transform.rotation * Vector3.forward * 1.0f;
                Bmrg.transform.RotateAround(tr.position, Vector3.up, 60);
                animationStage = 1;

                positionArray[0] = boomerangSpawnTransform.position + (boomerangSpawnTransform.rotation * (Vector3.forward + Vector3.right) * heldTime * 3);
                positionArray[1] = boomerangSpawnTransform.position + (boomerangSpawnTransform.rotation * (Vector3.forward + Vector3.left) * heldTime * 3);

                countingTime = false;
                heldTime = 0.0f;
            }
        }
        else        //solo se ejecuta si est� en la animaci�n
        {
            Debug.Log("Animation stage:" + animationStage);
            positionArray[2] = boomerangSpawnTransform.position;

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

    public void StopTimeCounter(float heldTime, float startHeld)
    {
        heldTime = Time.time - startHeld;
    }
    */
}
