using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class enemyMovement : MonoBehaviour
{
    public Animator animator;
    AudioSource audioSource;
    scoreManage scoreManage;
    public GameObject laser;
    targetControll targetController;
    public float enemySpeed;
    bool died = false;
    float timer;
    bool shot = false;
    void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        scoreManage = GameObject.Find("Score manager").GetComponent<scoreManage>();
        targetController = GameObject.FindWithTag("controller").GetComponent<targetControll>();
        if(transform.position.x<20f) targetController.AddEnemy(gameObject);
    }
    void Update()
    {
        if(!died){
            transform.position = transform.position + new Vector3(0,-enemySpeed*Time.deltaTime,0);
            if(transform.position.x<20f && transform.position.y<=-7f){
                if(targetController.IfContain(gameObject)){
                    targetController.Remove(gameObject);
                }
                Destroy(gameObject);
            }
            if(transform.position.y<=4.5f && transform.position.x<20f && !shot){
                shot = true;
                StartCoroutine(Countdowntimer());
            }
        }
    }
    private IEnumerator Countdowntimer()
    {
        Instantiate(laser,transform.position,quaternion.identity);
        while (true)
        {
            timer = UnityEngine.Random.Range(0.75f,1.5f);
            yield return new WaitForSeconds(timer);
            Instantiate(laser,transform.position,quaternion.identity);
        }
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.gameObject.CompareTag("laser") && transform.position.y<=4.5f){
            if(targetController.IfContain(gameObject)){
                targetController.Remove(gameObject);
            }
            scoreManage.addScore(1);
            StartCoroutine(DestroySelf());
        }
        else if(other.gameObject.CompareTag("player")){
            if(targetController.IfContain(gameObject)){
                targetController.Remove(gameObject);
            }
            StartCoroutine(DestroySelf());
        }
    }
    private IEnumerator DestroySelf(){
        died = true;
        animator.SetBool("died", true);
        audioSource.Play();
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
