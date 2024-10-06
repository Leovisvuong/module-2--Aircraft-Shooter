using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
public class laserMovement : MonoBehaviour
{
    public float speed;
    AudioSource audioSource;
    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if(transform.position.x<20f && transform.position.x>-20f) audioSource.Play();
    }
    void Update()
    { 
        switch(transform.rotation.z){
            case 0:
                transform.position = transform.position + new Vector3(0,speed*Time.deltaTime,0);
                break;
            case >0:
                transform.position = transform.position + new Vector3(-speed*Time.deltaTime,speed*Time.deltaTime,0);
                break;
            case <0:
                transform.position = transform.position + new Vector3(speed*Time.deltaTime,speed*Time.deltaTime,0);
                break;
        }
        if(transform.position.x<20f && transform.position.x>-20f && (transform.position.y>=7f || transform.position.x>10f || transform.position.x<-10f)){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.CompareTag("enemy")){
            Destroy(gameObject);
        }
    }
}
