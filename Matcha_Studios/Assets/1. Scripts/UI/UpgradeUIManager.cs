using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradeUIManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    [TextArea(3, 10)]
     public string healthDesc1, energyDesc1, shieldDesc1;   
    //[Multiline(4)]
    public string healthDesc, energyDesc, shieldDesc;
    public void ShieldUpgrade()
    {
        descriptionText.text = shieldDesc1;
        descriptionText.color = Color.cyan;
    }
    public void EnergyUpgrade()
    {
        descriptionText.text = energyDesc1;
        descriptionText.color = Color.yellow;
    }
    
    public void HealthUpgrade()
    {
        descriptionText.text = healthDesc1;
        descriptionText.color = Color.red;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
