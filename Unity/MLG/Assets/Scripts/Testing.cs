using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    GameController gameController;

    public void SpawnGamer()
    {
        gameController.AddRecruit();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
