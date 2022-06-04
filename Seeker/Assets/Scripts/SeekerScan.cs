using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


namespace StarterAssets
{
    public class SeekerScan : MonoBehaviour
    {
        private GameObject target;

        [SerializeField] private int rayLength = 10;
        [SerializeField] private LayerMask layerMaskInteract;

        [SerializeField] private Image uiReticle;

        private StarterAssetsInputs input;
        private Camera MainCamera;


        private void Start()
        {
            input = GetComponent<StarterAssetsInputs>();
            MainCamera = Camera.main;
        }
        void Update()
        {
            RaycastHit hit;
            Vector3 forward = MainCamera.transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(MainCamera.transform.position, forward, out hit, rayLength, layerMaskInteract.value))
            {
                if (hit.collider.CompareTag("Hider"))
                {
                    target = hit.collider.gameObject;
                    ReticleActive();
                    // change rectile color

                    if (input.scan)
                    {
                        Debug.Log("I found you!");
                        target.SetActive(false);
                    }
                }
            }

            else
            {
                ReticleNormal();
            }
        }

        void ReticleActive()
        {
            uiReticle.color = Color.red;
        }

        void ReticleNormal()
        {
            uiReticle.color = Color.white;
        }

    }
}