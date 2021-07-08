using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] Camera fpsCamera;
        [SerializeField] RigidbodyFirstPersonController fpsController;
        [SerializeField] float zoomedOutFOV = 60f;
        [SerializeField] float zoomedInFOV = 20f;
        [SerializeField] float zoomedInSensitivity = 0.5f;
        [SerializeField] float zoomedOutSensitivity = 2f;

        bool zoomedInToggle = false;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (zoomedInToggle == false)
                {
                    zoomedInToggle = true;
                    fpsCamera.fieldOfView = zoomedInFOV;
                    fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
                    fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
                }
                else
                {
                    zoomedInToggle = false;
                    fpsCamera.fieldOfView = zoomedOutFOV;
                    fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
                    fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
                }
            }

        }
    }
}