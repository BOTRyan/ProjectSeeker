using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends PlayerController
/// It will be used to load on players robots to give them abilites and condense code
/// </summary>
public class TeleporterHider : StarterAssets.PlayerController
{
    public GameObject markerPrefab;
    private GameObject teleportMarker;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (input.interact)
        {

            if (teleportMarker != null)
            {
                controller.enabled = false;
                transform.position = teleportMarker.transform.position;
                transform.rotation = Quaternion.Euler(0f, teleportMarker.transform.rotation.y, teleportMarker.transform.rotation.z);
                Destroy(teleportMarker);
                controller.enabled = true;
            }
            else
            {
                if (Grounded) teleportMarker = Instantiate(markerPrefab, transform.position, Quaternion.Euler(-90f, transform.rotation.y, transform.rotation.z), null);
            }

            input.interact = false;
        }
    }
}
