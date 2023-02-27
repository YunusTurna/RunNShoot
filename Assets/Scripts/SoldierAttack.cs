using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack: MonoBehaviour
{
    [SerializeField] GameObject soldierAttackObject;
    Vector3 spawnPoint;
    private bool start;
    void Start()
    {
        spawnPoint =  new Vector3(transform.position.x - 3 , transform.position.y , transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
