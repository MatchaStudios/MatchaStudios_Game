using System.Collections;
using TMPro;
using UnityEngine;

public class OneOffTypewrtier : MonoBehaviour
{
    public float typingSpeed = 0.1f; // Adjust the speed of typing
    public TextMeshProUGUI textComponent; // Reference to the UI Text component
    private string fullText;
    private int textIndex = 0;
    private string currentText = "";
    // Start is called before the first frame update

    void Start()
    {
        // Store the full text from the Text component
        fullText = textComponent.text;
        textComponent.text = ""; // Clear the initial text
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
        while (textIndex < fullText.Length)
        {
            // Add the next character to the current text
            currentText += fullText[textIndex];

            // Update the Text component with the current text
            textComponent.text = currentText;

            // Move to the next character
            textIndex++;

            // Wait for the specified typing speed
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(.5f);
        textComponent.text = "";
        currentText = "";
        textIndex = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
