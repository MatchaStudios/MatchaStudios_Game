using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public TypewriterEffect effect;
    [SerializeField] Text timerText;
    [SerializeField] float remainingTime;
    public bool canTick = true;
    public bool expired = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canTick)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                if (remainingTime < 20f)
                {
                    timerText.color = Color.yellow;
                }
                if (remainingTime < 10f)
                {
                    timerText.color = Color.red;
                }
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                if (!expired)
                {
                    expired = true;
                    effect.EndType();
                }
                timerText.color = Color.red;
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Pause()
    {
        //pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
