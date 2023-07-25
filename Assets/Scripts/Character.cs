using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public float hp = 1;

    void Update()
    {
        if (hp <= 0)
        {
            //Animacion de muerte
            //Destroy(gameObject);
        }
    }
    public void TakeDamage(int _value)
    {
        hp -= _value;
        Debug.Log("hp: " + hp);
    }
}
