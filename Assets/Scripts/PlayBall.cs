using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBall : MonoBehaviour
{
    public TriggerBall script;
    // Start is called before the first frame update
    void Start()
    {
        if (script.ball)
        {
            Debug.Log("Shu hui");
            GetComponent<Animator>().SetTrigger("BallTrigger");
        }
    }

}
