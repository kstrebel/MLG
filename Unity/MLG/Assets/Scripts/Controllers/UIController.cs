using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text scoreText;

    public int GamerScore{
        get { return int.Parse(scoreText.text); }
        set { scoreText.text = value.ToString(); } 
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
