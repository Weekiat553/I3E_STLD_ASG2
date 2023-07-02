/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Dont destroy audio script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
/// <summary>
/// Audio not destroyed when load to other screens
/// </summary>
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
