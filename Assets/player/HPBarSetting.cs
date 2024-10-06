using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class HPBarSetting : MonoBehaviour
{
    public Image HPBar;
    scoreManage scoreManage;
    public GameObject main;
    public GameObject lose;
    public static int turn=0;
    MyscoreUIController scoreManageUI;
    public static float HPBarColorR;
    public static float constHPBarColorG;
    public static float HPBarColorB;
    public static float HPBarColorG;
    private float NewHPBarColorG;
    float HPBeforeLost;
    float HPPercentage;
    float playerMaxHP;
    public static float playerRemainingHP;
    public void restart(){
        playerMaxHP = playerRemainingHP = 50f;
        HPBarColorR = HPBar.color.r;
        HPBarColorB = HPBar.color.b;
        if(constHPBarColorG == 0) constHPBarColorG = HPBar.color.g;
        HPBarColorG = constHPBarColorG;
        HPBar.color = new Color(HPBarColorR,HPBarColorG,HPBarColorB);
        HPBar.fillAmount = 1;
    }
    void Start(){
        scoreManage = GameObject.Find("Score manager").GetComponent<scoreManage>();
        scoreManageUI = GameObject.FindWithTag("score UI controller").GetComponent<MyscoreUIController>();
        playerMaxHP = playerRemainingHP = 50f;
        HPBarColorR = HPBar.color.r;
        HPBarColorB = HPBar.color.b;
        constHPBarColorG = HPBarColorG = HPBar.color.g;
    }
    void Update(){
        if(playerRemainingHP<=0f){
            turn++;
            scoreManageUI.addToList(turn,scoreManage.Score());
            lose.SetActive(true);
            main.SetActive(false);
            HPBar.fillAmount = 0;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("enemy")){
            HPBeforeLost = playerRemainingHP;
            playerRemainingHP -= 4f;
        }
        else if(other.gameObject.CompareTag("enemy laser")){
            HPBeforeLost = playerRemainingHP;
            playerRemainingHP -= 1f;
        }
        if(playerRemainingHP<0) playerRemainingHP = 0;
        StartCoroutine(CountdownHP());
    }
    private IEnumerator CountdownHP()
    {
        while (HPBeforeLost > playerRemainingHP)
        {
            yield return new WaitForSeconds(0.05f);
            HPBeforeLost -= 0.2f;
            HPPercentage = HPBeforeLost*100f/playerMaxHP;
            NewHPBarColorG = HPPercentage*HPBarColorG/100f;
            HPBar.color = new Color(HPBarColorR,NewHPBarColorG,HPBarColorB);
            HPBar.fillAmount = HPPercentage/100f;
        }
    }
}