using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;

    float lerpSpeed;

    public float    initHealth,
                    curHealth,
                    maxHealth;


    void Start()
    {
        initHealth = maxHealth;
        curHealth = maxHealth;

    }

    private void Update()
    {
        healthText.text = "Health: " + curHealth + "%";

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        lerpSpeed = 3f * Time.deltaTime;

        barFiller();
        ColorChanger(); 
    }

    void barFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, curHealth /maxHealth, lerpSpeed);
    }


    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (curHealth /maxHealth));
        healthBar.color = healthColor;
    }

    //----

    public virtual void TakeDamage(float damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        
    }

    //---
     
    public void Heal(float heal)
    {
        if (curHealth < maxHealth)
            curHealth += heal;
    }

}
