using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimator : MonoBehaviour
{
    public static Action shieldDamaged;
    public Color[] colourArray = new Color[] {Color.white, Color.red, Color.green, Color.blue};
    [SerializeField]
    GameObject shieldMesh;
    Renderer shieldRenderer;
    // Start is called before the first frame update
    void Start()
    {

        shieldRenderer = shieldMesh.GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        shieldDamaged?.Invoke();
        shieldRenderer.material.SetColor("_MainColor",Color.Lerp(shieldRenderer.material.color,Color.red,.1f));
        shieldMesh.SetActive(true);
        WaitHelper.Wait(3, () =>
        {
            if (shieldMesh != null) shieldMesh.SetActive(false);
        });
    }
}
