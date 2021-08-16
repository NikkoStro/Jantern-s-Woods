using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    public int scoreValue = 0;
    public Text score;

    public int crystalCount = 0;
    public int maxCrystals;
    public Text crystals;
    public GameObject goal;
    public Text obj;
    public GameObject complete;

    public Player P1;

    // Start is called before the first frame update
    void Start()
    {
        //score = GetComponent<Text>();
        //crystals = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        crystals.text = "Crystals: " + crystalCount + "/" + maxCrystals;

        if(crystalCount == maxCrystals)
        {
            //obj.color = Color.green;
            complete.SetActive(true);
        }

        if(crystalCount == maxCrystals && P1.objective1 == true)
        {
            goal.SetActive(false);
        }
    }
}
