/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Destroy object script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    /// <summary>
    /// Destroy function will run when its called
    /// </summary>
    public void DestroyItem()
    {
        Destroy(gameObject); // destroy gameobject
    }
}
