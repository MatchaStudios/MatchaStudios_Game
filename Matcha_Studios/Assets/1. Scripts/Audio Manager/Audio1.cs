using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic("Ambience");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
