using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimator : MonoBehaviour
{
    public static Action shieldDamaged;
    [SerializeField]
    GameObject shieldMesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        shieldDamaged?.Invoke();
        shieldMesh.SetActive(true);
        WaitHelper.Wait(3, () =>
        {
            if (shieldMesh != null) shieldMesh.SetActive(false);
        });
    }
}
