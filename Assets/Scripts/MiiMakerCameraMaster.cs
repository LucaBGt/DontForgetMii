using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MiiMakerCameraMaster : MonoBehaviour
{
    public CinemachineVirtualCamera detailCam;
    private void Awake()
    {
        StaticEvents.ReplaceCamTarget.AddListener(UpdateCamDetail);
    }

    void UpdateCamDetail(Transform newTarget)
    {
        detailCam.Follow = newTarget;
    }
}
