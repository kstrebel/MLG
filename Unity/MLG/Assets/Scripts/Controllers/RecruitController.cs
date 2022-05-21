using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecruitController : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField]
    public TMP_Text text1;
    [SerializeField]
    public float Delay;

    //[SerializeField]
    public GameController GameController { get; set; }

    private int score = 0;
    private float timeSince = 0;

    void Start()
    {
        text1.text = score.ToString();
    }

    void Update()
    {
        timeSince += Time.deltaTime;

        if (timeSince >= Delay)
        {
            ++score;
            timeSince = 0;

            text1.text = score.ToString();
            ++GameController.GamerScore;
        }
    }

    private void OnMouseEnter()
    {
        
    }
}
