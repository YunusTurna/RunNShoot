using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack: MonoBehaviour
{
    [SerializeField] GameObject soldier;
    Vector3 spawnPoint;
    private bool start;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  soldier.transform.position;
        
    }
    
}
