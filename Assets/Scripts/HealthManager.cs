using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public Image healthBar1;

    public float healthAmount = 100f;
    public float healthAmount1 = 100f;


    void Start()
    {
        
    }

    void Update()
    {
        if (healthAmount <= 0 || healthAmount1 <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage1(20);
        }

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void TakeDamage1(float damage)
    {
        healthAmount1 -= damage;
        healthBar1.fillAmount = healthAmount1 / 100f;
    }

    public void Heal1(float healingAmount)
    {
        healthAmount1 += healingAmount;
        healthAmount1 = Mathf.Clamp(healthAmount1, 0, 100);

        healthBar1.fillAmount = healthAmount1 / 100f;
    }
}
