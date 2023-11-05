using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public List<string> subtitlesList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        subtitlesList.Add("Hey, is someone there? Help us, stranger! Bandits were attacking this humble station.");
        subtitlesList.Add("Whole station is stuck. We have no fuel, no parts and we’re running low on food! We need to get back to the nearest planet. Help us, please.");
        subtitlesList.Add("Dang pirates, ruining MY business.");
        subtitlesList.Add("Aw hell I thought they all died. I apologise for the inconvenience.");
        subtitlesList.Add("These damn pirates, I’ll teach em one day.");
        subtitlesList.Add("Whoa...There’s more of those bastards?!");
        subtitlesList.Add("Those parts could really save us. Just need a tiny amount of fuel to push us to the nearest planet.");
        subtitlesList.Add("Hey, thanks a lot! We can finally make this station movin’ again! Thought we were gonna die out here. Thanks again, guys. And for the trouble, here's yer reward.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
