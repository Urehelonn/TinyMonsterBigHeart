using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnLoadChangeScene : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
