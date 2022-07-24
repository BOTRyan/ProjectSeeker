using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager instance;

    public GameObject cameraPrefab;
    public GameObject cameraFollowPrefab;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}