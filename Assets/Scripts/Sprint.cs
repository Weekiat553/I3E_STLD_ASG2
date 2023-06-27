using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    float stamina = 5;
    float maxStamina = 5;
    float runSpeed;
    float walkSpeed;
    player pScript;
    bool isRunning;

    void Start()
    {
        pScript = GetComponent<player>();
        walkSpeed = pScript.movementSpeed;
        runSpeed = walkSpeed * 4;
    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
     //   pScript.movementSpeed;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
