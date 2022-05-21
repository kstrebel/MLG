using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public UIController uiController;

    public int GamerScore {
        get { return gamerScore; }
        set { gamerScore = value;
            uiController.GamerScore = gamerScore;
        } }
    private int gamerScore;

    
    public float Cash { get; set; }

    public int score { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
