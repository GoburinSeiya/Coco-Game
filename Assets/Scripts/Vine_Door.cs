using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine_Door : MonoBehaviour, IDamageable
{
    public float hp = 1;

    public void TakeDamage(int _value)
    {
        hp -= _value;
        Debug.Log("hp: " + hp);

        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
