using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimator : MonoBehaviour
{
    public static Action shieldDamaged;
    public Color[] colourArray = new Color[] {Color.cyan, Color.blue, Color.magenta,  Color.clear,Color.red};
    private int currentColor,length;
    [SerializeField]
    GameObject shieldMesh;
    Renderer shieldRenderer;
    // Start is called before the first frame update
    void Start()
    {
        currentColor = 0;
        length = colourArray.Length;
        shieldRenderer = shieldMesh.GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        shieldDamaged?.Invoke();
        if(currentColor == length){
            currentColor =4;
        }
        else{
        currentColor = (currentColor+1)%length;
        }
        */
        //shieldRenderer.material.SetColor("_MainColor",Color.Lerp(shieldRenderer.material.color,colourArray[currentColor],.1f));
        shieldMesh.SetActive(true);
        WaitHelper.Wait(3, () =>
        {
            if (shieldMesh != null) shieldMesh.SetActive(false);
        });
    }
}
