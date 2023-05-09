using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(0, speed * Time.deltaTime, 0);
    }
}
