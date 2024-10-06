using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loseUIManager : MonoBehaviour
{
    public Button back;
    public TextMeshProUGUI loseText;
    public GameObject gameStartUI;
    public GameObject gameLoseUI;
    public GameObject main;
    scoreManage scoreManage;

    void Start(){
        scoreManage = GameObject.Find("Score manager").GetComponent<scoreManage>();
        back.onClick.AddListener(doBack);
    }
    void Update(){
        if(gameLoseUI.activeInHierarchy) main.SetActive(false);
        loseText.text = "You Lose!\nScore: " + scoreManage.Score();
    }
    void doBack(){
        gameStartUI.SetActive(true);
        gameLoseUI.SetActive(false);
    }
}
