using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public Action endedObjective;
    public KingOfTheHill kothObj;
    public float typingSpeed = 0.1f; // Adjust the speed of typing
    public Text textComponent; // Reference to the UI Text component

    private string fullText;
    private string currentText = "";
    private int textIndex = 0;

    private string addText = "NAV DATA ACQUIRED";
    void Start()
    {
        // Store the full text from the Text component
        fullText = textComponent.text;
        textComponent.text = ""; // Clear the initial text

    }

    public void StartTyping()
    {
        StartCoroutine(TypeText());
    }

    public void EndType()
    {
        endedObjective?.Invoke();
        fullText = addText;
        currentText = "";
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
        textIndex=0;
    }

    private void OnEnable()
    {

        kothObj.playerEntered += StartTyping;
    }
    private void OnDisable()
    {

        kothObj.playerEntered -= StartTyping;
    }
}
