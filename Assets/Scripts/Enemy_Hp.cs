using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hp : Character
{
    private Material Mat;
    private Transform tr;
    //barra de vida
    GameObject cube;
    //valor que no cambia
    public float hpOffset = 5.0f;
    //valor inicial
    public float hpBarSize = 1.0f;

    //valor que va a ir cambiando
    private float CurrentHpBarSize = 0.0f;

    //valor fijo
    private float hpInicial;
    public float percentage;
    void Start()
    {
        //Material para la barra de vida del enemigo
        Mat = Resources.Load("Materials/HP_bar", typeof(Material)) as Material;
        //Se le da el valor a la constante de hp inicial
        hpInicial = hp;
        tr = GetComponent<Transform>();

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(this.gameObject.transform);
        cube.transform.position = tr.position + new Vector3(0.0f, hpOffset, 0.0f);
        cube.transform.localScale = new Vector3(hpBarSize, hpBarSize/4, hpBarSize/4);
        cube.GetComponent<Renderer>().material = Mat;
    }

    void Update()
    {
        percentage = hp * 100 / hpInicial;
        CurrentHpBarSize = hpBarSize * percentage / 100;

        //Este if solo está ahí para que no se valla a los negativos ni se vea un error donde aparece en negro
        if (CurrentHpBarSize <= 0)
        { CurrentHpBarSize = 0.001f; }

        cube.transform.localScale = new Vector3(CurrentHpBarSize, hpBarSize / 4, hpBarSize / 4);
    }
}
