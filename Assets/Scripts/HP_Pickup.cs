using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Pickup : MonoBehaviour
{
    public int Heal_Amount;
    public Rotate rscript;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        int speed = Random.Range(5, 10)*10;
        rscript.speed = speed;
        //rb.velocity = Vector3.up * (speed/2); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            PlayerStats ps = (PlayerStats)player.GetComponent(typeof(PlayerStats));
            ps.Heal(Heal_Amount);
            Destroy(this.gameObject);
        }
        
    }
}
