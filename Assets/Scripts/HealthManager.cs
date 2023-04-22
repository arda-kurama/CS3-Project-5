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

    public GameObject bullet;
    public GameObject stickman;

    void Start()
    {
        
    }

    void Update()
    {
        if (healthAmount <= 0 || healthAmount1 <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (stickman.gameObject.name == "Stickman")
            {
                TakeDamage(25);
            }

            if (stickman.gameObject.name == "Stickman (1)")
            {
                TakeDamage1(25);
            }
        }
    }
}
