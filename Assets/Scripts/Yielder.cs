using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yielder : MonoBehaviour {
    
    public void needWait(int time)
    {
        StartCoroutine(Wait(time));
    }

    //yield to let player have some time to read information from panel;
    IEnumerator Wait(int tim)
    {
        yield return new WaitForSeconds(tim);
        Debug.Log("Finish yield.");
    }
}
