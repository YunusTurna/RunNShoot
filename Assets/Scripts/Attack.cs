using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject attackFront;
    [SerializeField] GameObject attackBack;
    SpriteRenderer sr;
    
    void Start()
    {
        attackFront.SetActive(false);
        attackBack.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sr.flipX == true)
        {
            if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(SetActiveBack());
        }

        }
        
        if(sr.flipX == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(SetActiveFront());
        }
        
        }

    IEnumerator SetActiveFront()
    {
        attackFront.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackFront.SetActive(false);
    }
    IEnumerator SetActiveBack()
    {
        attackBack.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackBack.SetActive(false);
    }
}
}
