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
        animationManager.PlayTargetAniamtion(weapon.OH_Axe_Light_Attack, true);
    }

    //HandleHeavyAttack

    public void HandleBoomerangAttack()
    {
        
    }
}
