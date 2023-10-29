using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image energyBar;
    float regenTimer;
    float shieldEnergy = 1f;
    float health = 1f;
    [SerializeField]
    private Image shieldBar;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image shieldVignette;
    [SerializeField]
    public GameObject player;

    private ShipEnergy shipEnergy;
    [SerializeField]
    //private Text shieldText;

    private void OnEnable()
    {
        ShieldAnimator.shieldDamaged += FlashVignette;
        ShieldAnimator.shieldDamaged += UpdateShieldBar;
    }
    private void OnDisable()
    {
        ShieldAnimator.shieldDamaged -= FlashVignette;
        ShieldAnimator.shieldDamaged -= UpdateShieldBar;
    }

    private void FlashVignette()
    {
        if (shieldBar.fillAmount > 0)
        {
            shieldVignette.gameObject.SetActive(true);
            WaitHelper.Wait(1, () =>
            {
                if (shieldVignette != null) shieldVignette.gameObject.SetActive(false);
            });
        }
    }

    private void UpdateShieldBar()
    {
        ResetEnergyTimer();
        if (shieldBar.fillAmount > 0)
        {
            shieldBar.fillAmount -= .10f;
            //int _foo = int.Parse(shieldText.text.TrimEnd('%'));
            //_foo -= 10;
            //shieldText.text = _foo.ToString() + "%";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        shipEnergy = player.GetComponent<ShipEnergy>();
    }

    // Update is called once per frame
    void Update()
    {
        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0f)
        {
            shieldBar.fillAmount += .2f * Time.deltaTime;
            shieldBar.fillAmount = Mathf.Clamp(shieldBar.fillAmount, 0, 1f);
            //int _foo = int.Parse(shieldText.text.TrimEnd('%'));
            //_foo += 10;
            //_foo= (int)Mathf.Lerp (_foo, 100, 0.1f);
            //_foo = Mathf.Clamp(_foo, 0, 100);
            //shieldText.text = _foo.ToString() + "%";
        }
        energyBar.fillAmount = shipEnergy.energy;
    }
    public void ResetEnergyTimer()
    {
        regenTimer = 1.5f;
    }
}
