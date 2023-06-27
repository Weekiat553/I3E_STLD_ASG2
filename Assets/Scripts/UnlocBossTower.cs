using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlocBossTower : MonoBehaviour
{
    public void buttionMethode()
    {

        GetComponent<Animator>().SetTrigger("BossStairs");

    }
}
