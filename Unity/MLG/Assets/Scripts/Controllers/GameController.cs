using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public UIController uiController;
    [SerializeField]
    public GameObject RecruitPrefab;

    [Header("Temporary")]
    [SerializeField]
    public int screenWidth;
    [SerializeField]
    public int screenHeight;

    public int GamerScore
    {
        get { return gamerScore; }
        set
        {
            gamerScore = value;
            uiController.GamerScore = gamerScore;
        }
    }
    private int gamerScore;


    public float Cash { get; set; }
    public int Score { get; set; }

    private List<RecruitController> recruits;// = new List<RecruitController>();

    public void AddRecruit()
    {
        Vector3 pos = new Vector3(Random.Range(screenWidth / (-2), screenWidth / 2), Random.Range(screenHeight / (-2), screenHeight / 2), 0);

        GameObject rec = GameObject.Instantiate<GameObject>(RecruitPrefab);
        rec.transform.position = pos;

        RecruitController recCon = rec.GetComponent<RecruitController>();

        recCon.GameController = this;
        recruits.Add(recCon);
    }

    void Start()
    {
        recruits = new List<RecruitController>();
    }

    void Update()
    {

    }
}
