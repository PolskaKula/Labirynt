using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private int TimeToEnd;

    void Start()
    {
        if (gameManager == null) gameManager = this;

        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Stopper()
    {
        TimeToEnd--;
    }
}
