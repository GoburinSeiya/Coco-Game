using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider sliderVida; // Referencia al componente Slider para controlar la longitud de la barra de vida

    public void SetVida(float vidaActual, float vidaMaxima)
    {
        sliderVida.gameObject.SetActive(vidaActual < vidaMaxima); // Mostrar la barra de vida solo si la vida actual es menor que la vida m�xima
        sliderVida.value = vidaActual / vidaMaxima; // Ajustar la longitud de la barra de vida seg�n la relaci�n entre vidaActual y vidaMaxima
    }
}
