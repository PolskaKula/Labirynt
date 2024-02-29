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
        portol.Player = player.transform;
        portol.Reciever = jinyPortol.portolKolajder;

        renderSurfaz.GetComponent<Renderer>().material = Instantiate(PortolMatsy);
        if (miCamera.targetTexture != null) miCamera.targetTexture.Release();
        miCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
    }

    private void Start()
    {
        renderSurfaz.GetComponent<Renderer>().material.mainTexture = jinyPortol.GetComponent<Porcial>().miCamera.targetTexture;
    }
}
