using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class targetControll : MonoBehaviour
{
    public static List<GameObject> enemyList = new List<GameObject>() {};
    private Queue<GameObject> note = new Queue<GameObject>();
    GameObject deleteEnemy;
    public void AddEnemy(GameObject element){
        enemyList.Add(element);
    }
    public GameObject TargetEnemy(){
        if(enemyList.Count == 0) return null;
        if(enemyList[0].transform.position.y<=4.5f && enemyList[0].transform.position.x<20f){
            deleteEnemy = enemyList[0];
            enemyList.RemoveAt(0);
            return deleteEnemy;
        }
        return null;
    }
    public bool IfContain(GameObject element){
        return enemyList.Contains(element);
    }
    public void Remove(GameObject element){
        enemyList.RemoveAt(enemyList.IndexOf(element));
    }
    void Update(){
    }
}
