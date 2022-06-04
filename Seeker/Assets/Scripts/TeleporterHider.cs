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

        if (_input.interact)
        {
            if (teleportMarker != null)
            {
                _controller.enabled = false;
                transform.position = teleportMarker.transform.position;
                transform.rotation = teleportMarker.transform.rotation;
                Destroy(teleportMarker);
                _controller.enabled = true;
            }
            else
            {
                teleportMarker = Instantiate(markerPrefab, transform.position, transform.rotation, null);
            }

            _input.interact = false;
        }
    }
}
