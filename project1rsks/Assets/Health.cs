using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public float maxHealth;
    public Image healthBar;

    public float currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {

        if (currentHealth > 0)
        {
            currentHealth -= amount;
            Debug.Log("health now " + currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //we ded
                Debug.Log("you are now ded");
            }
            healthBar.fillAmount = currentHealth / maxHealth;
        }

    }

}
