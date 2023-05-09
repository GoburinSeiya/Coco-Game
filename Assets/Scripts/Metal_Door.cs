using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal_Door : MonoBehaviour
{
    public Lever[] placedLevers; //Arreglo de objetos con el script de 'PlacedTorch'
    public int leverNumber;
    public int leverOn = 0;

    int getLitTorches()
    {
        int _activated = 0;
        for (int i = 0; i < leverNumber; i++)
            if (placedLevers[i].Activated)
                _activated++;

        return _activated;
    }

    void Start()
    {
        leverNumber = placedLevers.Length;
    }


    void Update()
    {
        leverOn = getLitTorches();
        if (leverOn == leverNumber)
        {
            //Se abre la puerta
            Destroy(this.gameObject);
        }

    }
}
