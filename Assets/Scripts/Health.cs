using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       healthText.text = "Health: " + PlayerMovement.can.ToString();
    }
}
