using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Text energyText;
    public Image[] energyPoints;

    float lerpSpeed;

    public float energy, maxEnergy = 100;

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    private void Update()
    {
        energyText.text = "Energy: " + energy + "%";

        if (energy > maxEnergy) energy = maxEnergy;

        lerpSpeed = 3f * Time.deltaTime;

        barFiller();
        ColorChanger();
    }

    void barFiller()
    {
        for(int i = 0; i < energyPoints.Length; i++)
        {
           energyPoints[i].enabled = !DisplayEnergyPoint(energy, i);
        }
    }


    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (energy / maxEnergy));
    }

    bool DisplayEnergyPoint(float _energy, int pointNumber)
    {
        return ((pointNumber * 10) >= _energy);
    }

    //----

    public virtual void UseEnergy(float fuel)
    {
        energy -= fuel;

        if (energy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnDestroy()
    {

    }

    //---

    public void Refuel(float refuel)
    {
        if (energy < maxEnergy)
            energy += refuel;
    }
}
