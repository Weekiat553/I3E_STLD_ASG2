using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTreasure : MonoBehaviour
{
    Enemy script;
    public GameObject TreasureDoor;
    void Start()
    {
        Debug.Log("F");
        script = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    public void OpenTreasureDoor()
    {
        if (script.ded)
        {
            Debug.Log("Test");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        OpenTreasureDoor();
    }
}
