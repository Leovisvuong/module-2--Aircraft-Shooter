using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float playerSpeed;
    public GameObject cameraObject;
    Camera camera;
    playerShoot playerShoot;
    public void restart(){
        transform.position = new Vector3(2,-3,transform.position.z);
        camera = cameraObject.GetComponent<Camera>();
        playerShoot = gameObject.GetComponent<playerShoot>();
    }
    void Start(){
        camera = cameraObject.GetComponent<Camera>();
        playerShoot = gameObject.GetComponent<playerShoot>();
        transform.position = new Vector3(2,-3,transform.position.z);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if((transform.position.x>=camera.orthographicSize*2-0.75f && horizontalInput>0) || (transform.position.x<=-camera.orthographicSize*2+0.75f && horizontalInput<0)){
            horizontalInput = 0;
        }
        if((transform.position.y>=camera.orthographicSize-0.75f && verticalInput>0) || (transform.position.y<=-camera.orthographicSize+0.75f && verticalInput<0)){
            verticalInput = 0;
        }
        transform.position = transform.position + new Vector3(horizontalInput * playerSpeed * Time.deltaTime, verticalInput * playerSpeed * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("3 laser")){
            playerShoot.changeShootCase(3);
        }
        else if(other.gameObject.CompareTag("double laser")){
            playerShoot.changeShootCase(2);
        }
        else if(other.gameObject.CompareTag("target laser")){
            playerShoot.changeShootCase(4);
        }
    }
}
