using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    /// <summary>
    /// DELETE LATER
    /// </summary>
    [SerializeField]
    private GameObject AbilityVFX;
    //
    [Header("Ability 1")]
    public Image abilityImage1;
    //public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown = 5;
    private bool isAbility1Cooldown = false;

    [Header("Ability 2")]
    public Image abilityImage2;
    //public Text abilityText1; 
    public KeyCode ability2Key;
    public float ability2Cooldown = 5;
    private bool isAbility2Cooldown = false;

    [Header("Ability 3")]
    public Image abilityImage3;
    //public Text abilityText1;
    public KeyCode ability3Key;
    public float ability3Cooldown = 5;
    private bool isAbility3Cooldown = false;

    [Header("Ability 4")]
    public Image abilityImage4;
    //public Text abilityText4;
    public KeyCode ability4Key;
    public float ability4Cooldown = 5;
    private bool isAbility4Cooldown = false;

    [Header("Ability 5")]
    public Image abilityImage5;
    //public Text abilityText5;
    public KeyCode ability5Key;
    public float ability5Cooldown = 5;
    private bool isAbility5Cooldown = false;

    private AbilityType activeAbility = AbilityType.None;

    private float currentAbility1Cooldown;
    private float currentAbility2Cooldown;
    private float currentAbility3Cooldown;
    private float currentAbility4Cooldown;
    private float currentAbility5Cooldown;

    //private bool isAbility1Cooldown;
    //private bool isAbility2Cooldown;
    //private bool isAbility3Cooldown;
    //private bool isAbility4Cooldown;
    //private bool isAbility5Cooldown;

    //private float currentAbility1Cooldown;
    //private float currentAbility2Cooldown;
    //private float currentAbility3Cooldown;
    //private float currentAbility4Cooldown;
    //private float currentAbility5Cooldown;


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
        abilityImage5.fillAmount = 0;

        //abilityText1.text = ""; 
    }

    // Update is called once per frame
    void Update()
    {
        if (activeAbility == AbilityType.None)
        {
            Ability1Input();
            Ability2Input();
            Ability3Input();
            Ability4Input();
            Ability5Input();
        }

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, AbilityType.Ability1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityImage2, AbilityType.Ability2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityImage3, AbilityType.Ability3);
        AbilityCooldown(ref currentAbility4Cooldown, ability4Cooldown, ref isAbility4Cooldown, abilityImage4, AbilityType.Ability4);
        AbilityCooldown(ref currentAbility5Cooldown, ability5Cooldown, ref isAbility5Cooldown, abilityImage5, AbilityType.Ability5);

    }
    /// <summary>
    /// DELETE LATER
    /// </summary>
    private void ShowAbilityVFx()
    {
        SoundManager.Instance.PlaySFX("Heal");
        AbilityVFX.SetActive(true);
        AbilityVFX.SetActive(true);
        WaitHelper.Wait(3, () =>
        {
            if (AbilityVFX != null) AbilityVFX.SetActive(false);
        });
    }

    //
    private void Ability1Input()
    {
        if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
            activeAbility = AbilityType.Ability1;
            ShowAbilityVFx();
        }
    }

    private void Ability2Input()
    {
        if (Input.GetKeyDown(ability2Key) && !isAbility2Cooldown)
        {
            isAbility2Cooldown = true;
            currentAbility2Cooldown = ability2Cooldown;
            activeAbility = AbilityType.Ability2;
            ShowAbilityVFx();
        }
    }

    private void Ability3Input()
    {
        if (Input.GetKeyDown(ability3Key) && !isAbility3Cooldown)
        {
            isAbility3Cooldown = true;
            currentAbility3Cooldown = ability3Cooldown;
            activeAbility = AbilityType.Ability3;
            ShowAbilityVFx();
        }
    }

    private void Ability4Input()
    {
        if (Input.GetKeyDown(ability4Key) && !isAbility4Cooldown)
        {
            isAbility4Cooldown = true;
            currentAbility4Cooldown = ability4Cooldown;
            activeAbility = AbilityType.Ability4;
            ShowAbilityVFx();
        }
    }


    private void Ability5Input()
    {
        if (Input.GetKeyDown(ability5Key) && !isAbility5Cooldown)
        {
            isAbility5Cooldown = true;
            currentAbility5Cooldown = ability5Cooldown;
            activeAbility = AbilityType.Ability5;
            ShowAbilityVFx();
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, AbilityType abilityType)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (activeAbility == abilityType)
                {
                    activeAbility = AbilityType.None;
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
            }
        }
    }

    private enum AbilityType
    {
        None,
        Ability1,
        Ability2,
        Ability3,
        Ability4,
        Ability5,
    }
}
