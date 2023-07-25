using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDetector : MonoBehaviour
{
    public string tagDetect = "PopUpElements";
    public string childNameUI = "UIobject";
    public float radius = 3f; // Radio de la esfera de detección
    //public GameObject otherObject;
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Tags otherTags = other.GetComponent<Tags>();

        //Comprueba que exista el script
        if (otherTags != null)
        {
            //Recorre el array de tags del objeto
            foreach (var tag in otherTags.tags)
            {
                //Cuando el tag coincide con el que se busca
                if(tagDetect == tag)
                {
                    Transform child = otherObject.transform.Find("UIobject");
                    child.gameObject.SetActive(true);
                    Debug.Log(child.name);
                }
            }
        }
        else 
        {
            Debug.Log("No hay");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Tags otherTags = other.GetComponent<Tags>();

        //Comprueba que exista el script
        if (otherTags != null)
        {
            //Recorre el array de tags del objeto
            foreach (var tag in otherTags.tags)
            {
                //Cuando el tag coincide con el que se busca
                if (tagDetect == tag)
                {
                    Transform child = otherObject.transform.Find("UIobject");
                    child.gameObject.SetActive(false);
                    Debug.Log(child.name);
                }
            }
        }
        else
        {
            Debug.Log("No hay");
        }
    }
}

