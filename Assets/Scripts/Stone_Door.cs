using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Door : MonoBehaviour
{
    public Torch[] placedTorches; //Arreglo de objetos con el script de 'PlacedTorch'
    public int torchNumber;
    public int torchesLit=0;

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
        torchNumber = placedTorches.Length;
    }

    
    void Update()
    {
        torchesLit = getLitTorches();
        if (torchesLit==torchNumber)
        {
            //Se abre la puerta
            Destroy(this.gameObject);
        }

    }
}
