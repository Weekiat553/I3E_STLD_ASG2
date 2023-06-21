using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    player pScript;
    public float speedBoost = 10f;

    float stamina = 5, maxStamina = 5;
    void Start()
    {
        pScript = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
