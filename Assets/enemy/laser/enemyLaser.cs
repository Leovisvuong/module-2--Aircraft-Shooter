using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    public float speed;
    AudioSource audioSource;
    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        if(transform.position.x<20f && transform.position.x>-20f) audioSource.Play();
    }
    void Update()
    {
        transform.position = transform.position + new Vector3(0,-speed*Time.deltaTime,0);
        if(transform.position.x<20f && transform.position.y<=-7f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.CompareTag("player")){
            Destroy(gameObject);
        }
    }
}
