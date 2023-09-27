using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private Image shieldBar;
    [SerializeField]
    private Image shieldVignette;
    [SerializeField]
    private GameObject player;

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
        shieldVignette.gameObject.SetActive(true);
        WaitHelper.Wait(1, () =>
        {
            if (shieldVignette != null) shieldVignette.gameObject.SetActive(false);
        });
    }

    private void UpdateShieldBar () {
        --shieldBar.fillAmount;
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
