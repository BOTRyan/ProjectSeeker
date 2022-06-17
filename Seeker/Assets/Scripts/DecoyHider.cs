using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends PlayerController
/// It will be used to load on players robots to give them abilites and condense code
/// </summary>
public class DecoyHider : StarterAssets.PlayerController
{
    public GameObject decoyPrefab;
    private GameObject decoyMarker;
    const int maxDecoys = 3;
    private int decoysPlaced = 0;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (input.interact)
        {
            if (decoysPlaced < maxDecoys)
            {
                decoyMarker = Instantiate(decoyPrefab, transform.position, transform.rotation, null) as GameObject;
                decoyMarker.GetComponent<DecoyInteraction>().ownerHider = gameObject;
                decoysPlaced++;
            }

            input.interact = false;
        }
    }
}
