using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTPUIController : MonoBehaviour
{
    public Button back;
    public GameObject gameStartUI;
    public GameObject gameHTPUI;
    public GameObject main;

    void Start(){
        back.onClick.AddListener(doBack);
    }
    void Update(){
        if(gameHTPUI.activeInHierarchy) main.SetActive(false);
    }
    void doBack(){
        gameStartUI.SetActive(true);
        gameHTPUI.SetActive(false);
    }
}
