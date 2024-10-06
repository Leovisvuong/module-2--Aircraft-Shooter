using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpMovement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position = transform.position + new Vector3(0,-speed*Time.deltaTime,0);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            Destroy(gameObject);
        }
    }
}
