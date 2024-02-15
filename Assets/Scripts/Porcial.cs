using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porcial : MonoBehaviour
{
    [SerializeField] Porcial jinyPortol;
    [SerializeField] Material PortolMatsy;

    public Camera miCamera;

    public Transform renderSurfaz;
    public Transform portolKolajder;

    public GameObject player;
    public Portol portol;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        portol = portolKolajder.GetComponent<Portol>();
    }
}
