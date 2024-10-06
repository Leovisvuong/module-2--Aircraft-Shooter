using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class laserTargetMovement : MonoBehaviour
{
    public float speed;
    targetControll targetController;
    private GameObject enemyTargeted;
    float noteValue;
    float Xvalue;
    float Yvalue;
    AudioSource audioSource;
    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if(transform.position.x<20f && transform.position.x>-20f) audioSource.Play();
        targetController = GameObject.FindWithTag("controller").GetComponent<targetControll>();
        if(transform.position.x<20) enemyTargeted = targetController.TargetEnemy();
    }

    void Update()
    {
        if(transform.position.x<20){
            if(transform.position.x>10 || transform.position.x<-10 || transform.position.y>5 || transform.position.y<-5){
                Destroy(gameObject);
            }
            if(enemyTargeted != null){
                Xvalue = enemyTargeted.transform.position.x-transform.position.x;
                Yvalue = enemyTargeted.transform.position.y-transform.position.y;
                noteValue = Xvalue;
                Xvalue = math.abs(Xvalue/Yvalue);
                if(Xvalue<1){
                    Xvalue *= noteValue/math.abs(noteValue);
                    Yvalue /= math.abs(Yvalue);
                }
                else{
                    Xvalue = noteValue/math.abs(noteValue);
                    Yvalue = math.abs(Yvalue/noteValue)*Yvalue/math.abs(Yvalue);
                }
                transform.position = transform.position + new Vector3(speed*Xvalue*Time.deltaTime,speed*Yvalue*Time.deltaTime,0);
            }
            else{
                transform.position = transform.position + new Vector3(0,speed*Time.deltaTime,0);
                enemyTargeted = targetController.TargetEnemy();
            }
        }
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.CompareTag("enemy")){
            Destroy(gameObject);
        }
    }
}
