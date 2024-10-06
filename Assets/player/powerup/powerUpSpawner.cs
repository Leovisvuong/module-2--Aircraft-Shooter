using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
    private GameObject TripleLaserPrefab;
    private GameObject DoubleLaser;
    private GameObject TargetLaser;
    private GameObject clonePrefab;
    public GameObject cameraObject;
    Camera camera;
    public static float timer;
    public void restart(){
        timer = 0f;
        camera = cameraObject.GetComponent<Camera>();
    }
    void Start()
    {
        camera = cameraObject.GetComponent<Camera>();
        TripleLaserPrefab = GameObject.FindWithTag("3 laser");
        DoubleLaser = GameObject.FindWithTag("double laser");
        TargetLaser = GameObject.FindWithTag("target laser");
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 25f){
            timer = 0f;
            float randomX = UnityEngine.Random.Range(-camera.orthographicSize*2+0.75f,camera.orthographicSize*2-0.75f);
            float randomPowerUp = UnityEngine.Random.Range(0f,3f);
            Vector3 spawnPosition = new Vector3(randomX,7,0);
            switch(randomPowerUp){
                case <1:
                    clonePrefab = TripleLaserPrefab;
                    break;
                case <=2:
                    clonePrefab = DoubleLaser;
                    break;
                case <=3:
                    clonePrefab = TargetLaser;
                    break;
            }
            Instantiate(clonePrefab,spawnPosition,quaternion.identity);
        }
    }
}
