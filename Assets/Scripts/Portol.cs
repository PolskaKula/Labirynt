using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portol : MonoBehaviour
{
    public Transform Player;
    public Transform Reciever;
    public bool isOverlapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOverlapping = false;
        }
    }

    private void Teleportation()
    {
        if (isOverlapping)
        {
            Vector3 portalToPlayer = Player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct > 0)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, Reciever.rotation);
                rotationDiff += 180;
                Player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionoffset = Quaternion.Euler(0f, dotProduct, 0f) * portalToPlayer;
                Player.position = positionoffset + Reciever.position;
            }
        }
    }
}
