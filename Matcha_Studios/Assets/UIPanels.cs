using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanels : MonoBehaviour
{
    // UI Panels
    public GameObject ObjectivePanel;
    public GameObject SuccessPanel;

    void Start()
    {
        Time.timeScale = 0f;

        Scene gameScene = SceneManager.GetActiveScene();

        if (gameScene.buildIndex == 1)
        {
            StartCoroutine(FadeInObjective());
            Time.timeScale = 1f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SuccessPanel.SetActive(true);
        }
    }

    IEnumerator FadeInObjective()
    {
        ObjectivePanel.SetActive(true);
        yield return new WaitForSeconds(3f);

        ObjectivePanel.SetActive(false);
    }

}
