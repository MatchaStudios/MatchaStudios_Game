using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    public Text shieldText;
    public Image shieldBar;

    float lerpSpeed;

    public float health, maxHealth = 100f;
    public float shield, maxshield = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        shield = maxshield;
    }

    // Update is called once per frame
    private void Update()
    {
        healthText.text = "Health: " + health + "%";

        shieldText.text = "Shield: " + shield + "%";

        if (health > maxHealth) health = maxHealth;

        if (shield > maxshield) shield = maxshield;

        lerpSpeed = 3f * Time.deltaTime;

        barFiller();
        ColorChanger(); 
    }

    void barFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/maxHealth, lerpSpeed);
        shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, shield / maxshield, lerpSpeed);
    }


    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health/maxHealth));
        healthBar.color = healthColor;
        shieldBar.color = healthColor;
    }

    //----

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        shield -= damage;

        if (health <= 0)
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
        if (health < maxHealth)
            health += heal;
    }

    public void shieldBoost(float heal)
    {
        if (shield < maxshield)
            shield += heal;
    }
}
