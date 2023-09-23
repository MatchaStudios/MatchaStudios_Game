using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    [Header("=== Player Only ===")]
    public Text healthText;
    public Image healthBar;

    [Header("=== For All ===")]
    public bool isAlive = true;

    float lerpSpeed;

    public float initHealth,
                    curHealth,
                    maxHealth;


    void Start()
    {
        isAlive = true;
        initHealth = maxHealth;
        curHealth = maxHealth;

    }

    private void Update()
    {
        // healthText.text = "Health: " + curHealth + "%";

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            curHealth = 0;
            isAlive = false;
        }

        lerpSpeed = 3f * Time.deltaTime;

        // barFiller();
        // ColorChanger(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SimpleBullet>(out SimpleBullet bullet))
        {
            if (bullet.team == tag)
            {
                // If it came from itself, do nothing.
            }
            else
            {
                TakeDamage(bullet.damage);
            }
        }
    }

    void barFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, curHealth / maxHealth, lerpSpeed);
    }


    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (curHealth / maxHealth));
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
