using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCanvasAnims : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public float animationDuration = 1.0f; // Duration of the animation in seconds
    private float startTime;
    public TextMeshProUGUI dmgTaken;
    public TextMeshProUGUI success;
    public TextMeshProUGUI completedDel;

    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;

    private IEnumerator AnimateTextValue(int targetValue, int startValue, TextMeshProUGUI target)
    {

        startTime = Time.time;
        float endTime = startTime + animationDuration;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / animationDuration;
            int newValue = Mathf.RoundToInt(Mathf.Lerp(startValue, targetValue, progress));
            UpdateTextValue(newValue, target);
            yield return null;
        }

        UpdateTextValue(targetValue, target);

    }
    private IEnumerator SetActive(GameObject targetObk)
    {
        targetObk.SetActive(true);
        yield return null;
    }
    private IEnumerator SetActiveWithDelay(GameObject targetObk)
    {
        yield return new WaitForSeconds(0.3f);
        targetObk.SetActive(true);
        yield return null;
    }
        private IEnumerator SwitchWithDelay()
    {
        yield return new WaitForSeconds(5.35f);
        SceneManager.LoadScene("UpgradeMenu");
        yield return null;
    }
    private void UpdateTextValue(int value, TextMeshProUGUI target)
    {
        target.text = value.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SequenceStart());
    }
    IEnumerator SequenceStart()
    {
        yield return StartCoroutine(SetActive(dmgTaken.gameObject));
        yield return StartCoroutine(AnimateTextValue(-20, 0, textMeshPro));
        yield return StartCoroutine(SetActive(success.gameObject));
        yield return StartCoroutine(AnimateTextValue(100, 0, textMeshPro1));
        textMeshPro1.text = "+" + textMeshPro1.text;
        yield return StartCoroutine(SetActive(completedDel.gameObject));
        yield return StartCoroutine(AnimateTextValue(200, 0, textMeshPro2));
        textMeshPro2.text = "+" + textMeshPro2.text;
        yield return StartCoroutine(SetActiveWithDelay(star1.gameObject));
        yield return StartCoroutine(SetActiveWithDelay(star2.gameObject));
        yield return StartCoroutine(SetActiveWithDelay(star3.gameObject));
        yield return StartCoroutine(SetActiveWithDelay(star4.gameObject));
        yield return StartCoroutine(SwitchWithDelay());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
