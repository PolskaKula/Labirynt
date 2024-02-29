using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        PortalCameraController();
    }

    void PortalCameraController()
    {
        Vector3 playerOffsetPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position - playerOffsetPortal;

        float ADBPR = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotDiff = Quaternion.AngleAxis(ADBPR, Vector3.up);
        Vector3 newCamPos = portalRotDiff * playerCamera.forward;
        newCamPos = new Vector3(-newCamPos.x, newCamPos.y, -newCamPos.z);

        transform.rotation = Quaternion.LookRotation(newCamPos, Vector3.up);
    }
}
