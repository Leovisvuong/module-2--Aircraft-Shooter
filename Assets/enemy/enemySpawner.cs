using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static float timer;
    public GameObject cameraObject;
    Camera camera;
    public void restart(){
        timer = 0f;
        camera = cameraObject.GetComponent<Camera>();
    }
    void Start()
    {
        timer = 0f;
        camera = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.75f){
            timer = 0f;
            float randomX = UnityEngine.Random.Range(-camera.orthographicSize*2+0.75f,camera.orthographicSize*2-0.75f);
            Vector3 spawnPosition = new Vector3(randomX,7,0);
            Instantiate(enemyPrefab,spawnPosition,quaternion.identity);
        }
    }
}
