using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Torch : MonoBehaviour
{
    //transform del jugador
    private Transform tr;
    GameObject Torch_Prefab;
    GameObject Torch;
    private bool inAnimation = false;

    private float start_time = 0.0f;
    public float attack_time = 0.35f; //0.35f
    private float time_attacking = 0.0f;

    public float attackSpeed;
    void Start()
    {
        tr = GetComponent<Transform>();
        Torch_Prefab = Resources.Load("Prefabs/Torch", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //se inicia el ataque
        if (Input.GetKey(KeyCode.T) && !inAnimation)
        {
            Debug.Log("Inicia el ataque");
            Torch = GameObject.Instantiate(Torch_Prefab);
            Torch.transform.SetParent(this.gameObject.transform);
            Torch.transform.rotation = tr.rotation;
            Torch.transform.position = tr.position;
            Torch.transform.position += Torch.transform.rotation * Vector3.forward * 2;
            Torch.transform.RotateAround(tr.position, Vector3.up, 60);

            Torch.transform.Rotate(60.0f, 0, 0);

            inAnimation = true;
            start_time = Time.time;
        }
        if (inAnimation && time_attacking < attack_time)
        {
            time_attacking = Time.time - start_time;
            Torch.transform.RotateAround(tr.position, Vector3.up, -45 * Time.deltaTime * attackSpeed);
        }
        else
        {
            inAnimation = false;
            time_attacking = 0;
            Destroy(Torch);
        }
    }
}
