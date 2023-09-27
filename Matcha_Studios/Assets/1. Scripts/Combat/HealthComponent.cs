using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    [Header("=== Player Only ===")]
    public Text             healthText;
    public Image            healthBar;

    [Header("=== For All ===")]
    public bool             isAlive = true;

    float                   lerpSpeed;

    public float            initHealth,
                            curHealth,
                            maxHealth;

    public ParticleSystem   deathParticle,
                            hitParticle;

    public GameObject GameManager;
    ObjectPooling objectPooling;


    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            objectPooling = GameManager.GetComponent<ObjectPooling>();
        }

        isAlive = true;
        initHealth = maxHealth;
        curHealth = maxHealth;
    }

    private void Update()
    {
        // healthText.text = "Health: " + curHealth + "%";
        if(curHealth > 0)
        {
            isAlive = true;
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        // Death
        if (curHealth <= 0)
        {
            curHealth = 0;
            isAlive = false;
            Debug.Log(gameObject.name);
            GameObject spawnedObject = objectPooling.GetObjectFromPool(deathParticle.name);
            if (spawnedObject != null)
            {
                spawnedObject.transform.position = transform.position;
                spawnedObject.transform.rotation = Quaternion.identity;
            }

            gameObject.SetActive(false);
        }

        lerpSpeed = 3f * Time.deltaTime;

        // barFiller();
        // ColorChanger(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SimpleBullet>(out SimpleBullet sbullet))
        {
            if (sbullet.team == tag)
            {
                // If it came from itself, do nothing.
            }
            else
            {
                if (hitParticle)
                {
                    GameObject spawnedObject = objectPooling.GetObjectFromPool(hitParticle.name);
                    if (spawnedObject != null)
                    {
                        spawnedObject.transform.position = other.transform.position;
                        spawnedObject.transform.rotation = Quaternion.identity;
                    }
                }
                TakeDamage(sbullet.damage);
            }
        }
        if (other.TryGetComponent<Missile>(out Missile missile))
        {
            if (tag == "Player")
            {
                TakeDamage(missile.damage);
            }
        }
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            if (tag == "AI")
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

    public virtual void TakeDamage(float damage)
    {
        curHealth -= damage;
        
        // Death
        //if (curHealth <= 0)
        //{
        //    GameObject spawnedObject = objectPooling.GetObjectFromPool(deathParticle.name);
        //    if (spawnedObject != null)
        //    {
        //        spawnedObject.transform.position = transform.position;
        //        spawnedObject.transform.rotation = Quaternion.identity;
        //    }

        //    gameObject.SetActive(false);
        //}
    }

    public void Heal(float heal)
    {
        if (curHealth < maxHealth)
            curHealth += heal;
    }

}
