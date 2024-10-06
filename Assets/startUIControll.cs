using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startUIControll : MonoBehaviour
{
    public Button HTP,myScore,start;
    public GameObject gameStartUI;
    public GameObject gameHTPUI;
    public GameObject gameMyScoreUI;
    public GameObject main;
    public GameObject playerObject;
    public GameObject scoreManageObject;
    public GameObject PUSpawnerObject;
    public GameObject enemySpawnerObject;
    playerMovement player;
    HPBarSetting HPBar;
    scoreManage score;
    powerUpSpawner PUSpawner;
    enemySpawner EnemySpawner;
    playerShoot shootStatus;
    void Start(){
        HTP.onClick.AddListener(doHTP);
        myScore.onClick.AddListener(doMyScore);
        start.onClick.AddListener(doStart);
        player = playerObject.GetComponent<playerMovement>();
        HPBar = playerObject.GetComponent<HPBarSetting>();
        score = scoreManageObject.GetComponent<scoreManage>();
        PUSpawner = PUSpawnerObject.GetComponent<powerUpSpawner>();
        EnemySpawner = enemySpawnerObject.GetComponent<enemySpawner>();
        shootStatus = playerObject.GetComponent<playerShoot>();
    }
    void Update(){
        if(gameStartUI.activeInHierarchy) main.SetActive(false);
    }
    void doHTP(){
        gameStartUI.SetActive(false);
        gameHTPUI.SetActive(true);
    }
    void doMyScore(){
        gameStartUI.SetActive(false);
        gameMyScoreUI.SetActive(true);
    }
    void doStart(){
        gameStartUI.SetActive(false);
        main.SetActive(true);
        player.restart();
        HPBar.restart();
        score.restart();
        PUSpawner.restart();
        EnemySpawner.restart();
        shootStatus.restart();
    }
}
