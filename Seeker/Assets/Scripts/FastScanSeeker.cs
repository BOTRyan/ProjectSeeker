using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class extends PlayerController
/// It will be used to load on players robots to give them abilites and condense code
/// </summary>
public class FastScanSeeker : StarterAssets.PlayerController
{

    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;

    [SerializeField] private Image uiReticle;

    // scanning
    const float maxScanTimer = 1;
    private float scanTimer = 0;
    const float maxScanCoolDown = 3;
    private float scanCoolDown = 0;
    private bool onTarget;

    private Camera MainCamera;

    public override void Start()
    {
        base.Start();
        MainCamera = Camera.main;
    }

    public override void Update()
    {
        base.Update();

        RaycastHit hit;
        Vector3 forward = MainCamera.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(MainCamera.transform.position, forward, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Hider"))
            {
                onTarget = true;
            }
            else
            {
                onTarget = false;
            }
        }
        else
        {
            onTarget = false;
        }

        if (input.scan && scanCoolDown <= 0)
        {
            uiReticle.fillAmount = scanTimer / maxScanTimer;

            if (scanTimer > maxScanTimer)
            {
                if (onTarget)
                {
                    Debug.Log("I found you!");
                    scanTimer = 0;
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("Nothing!");
                    scanTimer = 0;
                }

                scanCoolDown = maxScanCoolDown;
            }
            else
            {
                scanTimer += Time.deltaTime;
            }
        }
        else
        {
            scanTimer = 0;
            uiReticle.fillAmount -= Time.deltaTime * 4;
        }

        ScanCoolDown();
    }

    private void ScanCoolDown()
    {
        if (scanCoolDown <= 0)
        {
            scanCoolDown = 0;
            uiReticle.color = Color.white;
        }
        else
        {
            scanCoolDown -= Time.deltaTime;
            uiReticle.fillAmount = scanCoolDown / maxScanCoolDown;
            uiReticle.color = Color.red;
        }
    }
}
