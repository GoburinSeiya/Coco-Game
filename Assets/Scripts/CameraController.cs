using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    public Transform player; // el objeto a seguir con la cámara
    public float distanceCamPlayer = 10.0f;
    public float yMinLimit = 5.0f;
    public float yMaxLimit = 50.0f;
    public float heightAngle = 45.0f;
    public float[] posCamera;
    public float actualRotation;
    public int cont = 0;
    public float gradosPorSegundos = 45.0f;
    public float rayDistance = 50.0f;
    public bool reinicio = false;

    private float x = 45.0f;
    private float y = 45.0f;
    
    private void Start()
    {
        posCamera = new float[4];
        posCamera[0] = 45.0f;
        posCamera[1] = 135.0f;
        posCamera[2] = 225.0f;
        posCamera[3] = 315.0f;

        Vector3 angulos = transform.eulerAngles;
        x = angulos.y;
        y = angulos.x;

        transform.rotation = Quaternion.Euler(heightAngle, posCamera[cont], 0);
        transform.position = transform.rotation * new Vector3(0.0f, 0.0f, -distanceCamPlayer) + player.position;
    }
    void LateUpdate()
    {
        if (player)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cont += 1;
                if (cont > 3) 
                { 
                    cont=0;                    reinicio = true;
                }
            }
            if (Input.mouseScrollDelta.y>0)
            {
                distanceCamPlayer -= 1.25f;
            }
            else if(Input.mouseScrollDelta.y<0) 
            {
                distanceCamPlayer += 1.25f;
            }
            if (transform.eulerAngles.y < posCamera[cont] || reinicio == true)  
            {
                Debug.Log(transform.eulerAngles.y + " " + posCamera[cont]);
                transform.RotateAround(player.transform.position, Vector3.up, 45 * Time.deltaTime);
                transform.position = transform.rotation * new Vector3(0.0f, 0.0f, -distanceCamPlayer) + player.position;
                if(reinicio==true && Mathf.Round(transform.eulerAngles.y) == posCamera[cont])
                {
                    reinicio=false;
                }
            }
            //transform.RotateAround(player.transform.position, Vector3.right, i * Time.deltaTime);
            transform.position = transform.rotation * new Vector3(0.0f, 0.0f, -distanceCamPlayer) + player.position;

            distanceCamPlayer = Mathf.Clamp(distanceCamPlayer, yMinLimit, yMaxLimit);
        }
    }

    public void move() 
    { 
        
    }
}
