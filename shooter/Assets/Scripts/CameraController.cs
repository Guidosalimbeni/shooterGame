using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera followCamera;
    [SerializeField]
    private float verticalSensitivity = 1;
    [SerializeField]
    CinemachineFreeLook freeLockCamera;


    private CinemachineComposer aim;
    

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            freeLockCamera.Priority = 100;
            freeLockCamera.m_RecenterToTargetHeading.m_enabled = false;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            freeLockCamera.Priority = 0;
            freeLockCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (Input.GetMouseButtonUp(1) == false)
        {
            aim.m_TrackedObjectOffset.y += Input.GetAxis("Mouse Y") * verticalSensitivity;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 50f);

        }

        

    }
}
