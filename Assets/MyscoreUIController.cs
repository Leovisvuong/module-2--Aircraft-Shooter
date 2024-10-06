using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class MyscoreUIController : MonoBehaviour
{
    public Button back;
    public GameObject gameStartUI;
    public GameObject gameMyScoreUI;
    public TextMeshProUGUI myScoreTextTotal;
    public GameObject main;
    public static int scoreSum=0;
    public static int maxScore=0;
    public static List<(int turn, int score)> myTotalScore = new List<(int turn, int score)>();
    public void addToList(int playTurn, int playScore){
        if(myTotalScore.Count>6) myTotalScore.RemoveAt(0);
        myTotalScore.Add((playTurn,playScore));
        scoreSum += playScore;
        maxScore = math.max(maxScore,playScore);
    }
    void Start(){
        back.onClick.AddListener(doBack);
    }
    void Update(){
        if(gameMyScoreUI.activeInHierarchy) main.SetActive(false);
        if(myTotalScore.Count > 0){
            myScoreTextTotal.text = "  Turn:";
            foreach(var i in myTotalScore){
                myScoreTextTotal.text += i.turn + "\t";
            }
            myScoreTextTotal.text += "\nScore:";
            foreach(var i in myTotalScore){
                myScoreTextTotal.text += i.score + "\t";
            }
            myScoreTextTotal.text += "\nTotal Score: " + scoreSum + "\nHighest Score: " + maxScore;
        }
    }
    void doBack(){
        gameStartUI.SetActive(true);
        gameMyScoreUI.SetActive(false);
    }
}
