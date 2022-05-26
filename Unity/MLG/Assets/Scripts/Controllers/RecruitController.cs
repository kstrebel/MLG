using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecruitController : MonoBehaviour
{
    [SerializeField]
    private AudioSourceEx audioEX;

    [Header("Game Settings")]
    [SerializeField]
    private TMP_Text text1;
    [SerializeField]
    public float Delay;

    [Header("Audio Settings")]
    [SerializeField]
    private float minimumTimeBetweenPassiveSFX;
    private float maximumTimeBetweenPassiveSFX;

    //[SerializeField]
    public GameController GameController { get; set; }

    private int score = 0;
    private float timeSince = 0;
    private float sfxPassiveDelay;

    void Start()
    {
        text1.text = score.ToString();

        sfxPassiveDelay = Random.Range(minimumTimeBetweenPassiveSFX, maximumTimeBetweenPassiveSFX);
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

            sfxPassiveDelay -= timeSince;
        }

        if (sfxPassiveDelay < timeSince)
        {
            audioEX.Play();

            sfxPassiveDelay = Random.Range(minimumTimeBetweenPassiveSFX, maximumTimeBetweenPassiveSFX) + timeSince;
        }
    }
}
