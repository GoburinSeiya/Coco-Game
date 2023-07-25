using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private IDamageable collisionObject;
    public int Damage = 0;
    private bool dealDamage = false;
    public string[] interactables = new[] { "Lever", "Vines", "Chest", "Torch" };
    public int interactable = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"||other.gameObject.tag == interactables[interactable])
        {
            collisionObject = other.gameObject.GetComponent<IDamageable>();
            if (collisionObject != null)
            {
                collisionObject.TakeDamage(this.Damage);
            }
        }
    }
}
