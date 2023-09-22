using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldComponent : MonoBehaviour
{
    public Text shieldText;
    public Image shieldBar;

    float lerpSpeed;

    public float shield, maxshield = 100f;
    // Start is called before the first frame update
    void Start()
    {
        shield = maxshield;
    }

    // Update is called once per frame
    void Update()
    {
        shieldText.text = "Shield: " + shield + "%";

        if (shield > maxshield) shield = maxshield;

        lerpSpeed = 3f * Time.deltaTime;

        barFiller();
        ColorChanger();
    }

    void barFiller()
    {
        shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, shield / maxshield, lerpSpeed);
    }

    void ColorChanger()
    {
        Color shieldColour = Color.Lerp(Color.red, Color.green, (shield / maxshield));
        shieldBar.color = shieldColour;
    }

    public virtual void TakeDamage(float damage)
    {
        shield -= damage;
    }

    public void shieldBoost(float heal)
    {
        if (shield < maxshield)
            shield += heal;
    }
}
