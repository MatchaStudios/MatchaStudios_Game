using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitHelper : SingletonController<WaitHelper>
{
    IEnumerator WaitRoutine(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

    public static void Wait(float seconds, System.Action callback)
    {
        I.StartCoroutine(I.WaitRoutine(seconds, callback));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
