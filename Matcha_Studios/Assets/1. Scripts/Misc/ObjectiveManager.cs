using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public SubMissionOne subMissionOne;
    public CountdownTimer timer;
    public List<GameObject> objectives = new List<GameObject>();
    public AcceptMission submission;
    public int currentObjective = 0;
    public Text objectiveText1;
    public Text objectiveText2;
    public Text objectiveText3;
    public Text objectiveText4;
    public GameObject subMissionComplete;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeObjectiveTxt2()
    {
        objectiveText2.gameObject.SetActive(false);

    }

    public void ChangeObjectiveTxt3()
    {
        objectiveText3.gameObject.SetActive(true);

    }
    public void HideObjectiveTxt3()
    {
        objectiveText3.gameObject.SetActive(false);

    }

    public void ChangeObjectiveTxt4()
    {
        objectiveText4.gameObject.SetActive(true);

    }

    public void HideObjectiveTxt4()
    {
        objectiveText4.gameObject.SetActive(false);

    }

    void subMissionCompletePanel()
    {
        StartCoroutine(FadeInComeplete());
    }

    IEnumerator FadeInComeplete()
    {
        subMissionComplete.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(subMissionComplete);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnEnable()
    {
        ObjectiveTrigger.markerEntered += UpdateObjectives;
        timer.countEnded += UpdateObjectives;
        submission.acceptedMission += UpdateObjectives;

        timer.countEnded += ChangeObjectiveTxt2;
        timer.countEnded += ChangeObjectiveTxt4;
        submission.acceptedMission += HideObjectiveTxt4;
        submission.acceptedMission += ChangeObjectiveTxt3;
        submission.rejectMission += ChangeObjectiveTxt4;

        subMissionOne.completedSubMissionOne += TriggerFinalObjective;
        subMissionOne.completedSubMissionOne += ChangeObjectiveTxt4;
        subMissionOne.completedSubMissionOne += HideObjectiveTxt3;
        subMissionOne.completedSubMissionOne += subMissionCompletePanel;

    }
    private void OnDisable()
    {
        ObjectiveTrigger.markerEntered -= UpdateObjectives;
        timer.countEnded -= UpdateObjectives;
        submission.acceptedMission += UpdateObjectives;

        timer.countEnded -= ChangeObjectiveTxt2;
        timer.countEnded -= ChangeObjectiveTxt4;
        submission.acceptedMission -= HideObjectiveTxt4;
        submission.acceptedMission -= ChangeObjectiveTxt3;
        submission.rejectMission -= ChangeObjectiveTxt4;

        subMissionOne.completedSubMissionOne -= TriggerFinalObjective;
        subMissionOne.completedSubMissionOne -= ChangeObjectiveTxt4;
        subMissionOne.completedSubMissionOne -= HideObjectiveTxt3;
        subMissionOne.completedSubMissionOne -= subMissionCompletePanel;

    }

    public void TriggerFinalObjective()
    {
        objectives[2].SetActive(false);
        objectives[1].SetActive(true);

        objectiveText1.gameObject.SetActive(false);
    }

    public void UpdateObjectives()
    {
        if (currentObjective == 0)
        {
            objectives[0].SetActive(false);
            objectives[1].SetActive(true);

        }
        else
        {
            objectives[1].SetActive(false);
            objectives[2].SetActive(true);
        }
        currentObjective++;
    }
}