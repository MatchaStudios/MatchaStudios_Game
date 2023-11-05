using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    public Subtitle subtitle;
    public GameObject subtitleUI;
    public TextMeshProUGUI subtitleText;
    public SubMissionOne subMissionOne;
    float textTimer;
    int currentSubtitle;
    public void SetSubtitleActive()
    {
        subtitleUI.SetActive(true);
    }
    public void SetSubtitleDeactive()
    {
        subtitleUI.SetActive(false);
    }
    public void SetSubtitleText(int a, float length)
    {
        SetSubtitleActive();
        subtitleText.text = subtitle.subtitlesList[a];
        textTimer = length;
    }

    private void OnEnable()
    {
        subMissionOne.triggeredNewAudio += SetSubtitleText;
    }
    private void OnDisable()
    {
        subMissionOne.triggeredNewAudio -= SetSubtitleText;

    }
    // Start is called before the first frame update
    void Start()
    {
        SetSubtitleActive();

    }

    // Update is called once per frame
    void Update()
    {
        textTimer -= Time.deltaTime;
        if (textTimer <= 0f)
        {
            SetSubtitleDeactive();
        }
    }
}
