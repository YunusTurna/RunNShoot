using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(SoldierMovement.touch == true){
            sr.flipX = true;
        }
        if(SoldierMovement.touch == false){
            sr.flipX = false;
        }
    }
}
   