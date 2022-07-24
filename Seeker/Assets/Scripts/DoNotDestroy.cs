using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy instance;

    void Awake()
    {
        if (instance == null) instance = this;

        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
