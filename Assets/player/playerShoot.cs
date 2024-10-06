using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class playerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject targetLaserPrefab;
    shotStatus shootCase;
    float timer;
    float timerUsingPowerUp;
    public static int caseNum = 1;
    public void changeShootCase(int value){
        caseNum = value;
        setShootCase();
    }
    private void setShootCase(){
        switch(caseNum){
            case 1:
                shootCase = shotStatus.normalshot;
                break;
            case 2:
                shootCase = shotStatus.doubleshot;
                timerUsingPowerUp = 10f;
                StartCoroutine(Countdowntimer());
                break;
            case 3:
                shootCase = shotStatus.tripleshot;
                timerUsingPowerUp = 10f;
                StartCoroutine(Countdowntimer());
                break;
            case 4:
                shootCase = shotStatus.targetshot;
                timerUsingPowerUp = 10f;
                StartCoroutine(Countdowntimer());
                break;
        }
    }
    public void restart(){
        timer = 2f;
        shootCase = shotStatus.normalshot;
    }
    void Start()
    {
        timer = 2f;
        shootCase = shotStatus.normalshot;
    }
    void Update()
    {
        timer += Time.deltaTime;
        switch(shootCase){
            case shotStatus.normalshot:
                if(Input.GetKeyDown(KeyCode.Space) && timer >= 0.25f){
                    Instantiate(laserPrefab,transform.position,quaternion.identity);
                    timer = 0f;
                }
                break;
            case shotStatus.doubleshot:
                if(timer >= 0.25f){
                    Instantiate(laserPrefab,new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z),quaternion.identity);
                    Instantiate(laserPrefab,new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z),quaternion.identity);
                    timer = 0f;
                }
                break;
            case shotStatus.tripleshot:
                if(timer >= 0.25f){
                    Instantiate(laserPrefab,new Vector3(transform.position.x-0.1f,transform.position.y,transform.position.z),Quaternion.Euler(0,0,45));
                    Instantiate(laserPrefab,new Vector3(transform.position.x+0.1f,transform.position.y,transform.position.z),Quaternion.Euler(0,0,-45));
                    Instantiate(laserPrefab,transform.position,quaternion.identity);
                    timer = 0f;
                }
                break;
            case shotStatus.targetshot:
                if(Input.GetKeyDown(KeyCode.Space) && timer >= 0.25f){
                    Instantiate(targetLaserPrefab,transform.position,quaternion.identity);
                    timer = 0f;
                }
                break;
        }
        
    }
    private IEnumerator Countdowntimer(){
        while(timerUsingPowerUp > 0f){
            yield return new WaitForSeconds(1f);
            timerUsingPowerUp--;
        }
        caseNum = 1;
        setShootCase();
    }
    enum shotStatus{
        normalshot,
        doubleshot,
        tripleshot,
        targetshot,
    }
}
