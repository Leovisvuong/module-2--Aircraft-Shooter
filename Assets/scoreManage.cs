using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreManage : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public static int score = 0;
    public int Score(){
        return score;
    }
    public void restart(){
        score = 0;
    }
    public void addScore(int amount){
        score += amount;
    }
    void Update()
    {
        scoretext.text = "Score: " + score;
    }
}
