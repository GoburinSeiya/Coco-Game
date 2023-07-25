using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaManager : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;
    public int stamina;

    private WaitForSeconds tick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    public static StaminaManager instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void useStamina(int amount)
    {
        if (stamina - amount >= 0)
        {
            stamina -= amount;
            staminaBar.value = stamina;
            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("not enough stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (stamina < maxStamina)
        {
            stamina += maxStamina / 100;
            staminaBar.value = stamina;
            yield return tick;
        }
        regen = null;
    }
}
