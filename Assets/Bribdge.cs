using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bribdge : MonoBehaviour
{
    public int torchNumber;
    public int torchesLit = 0;

    private Transform tr;
    public Vector3 endPos;
    public float moveSpeed = 0.03f;

    int getLitTorches()
    {
        int _torchesLit = 0;
        for (int i = 0; i < torchNumber; i++)
            if (placedTorches[i].lit)
                _torchesLit++;

        return _torchesLit;
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        torchNumber = placedTorches.Length;
    }

    void Update()
    {
        torchesLit = getLitTorches();
        if (torchesLit == torchNumber)
        {
            tr.position = Vector3.MoveTowards(tr.position, endPos, moveSpeed);
        }
    }
}
