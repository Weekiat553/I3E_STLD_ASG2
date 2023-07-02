/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Ball damage player script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
/// <summary>
/// Damage amount for ball
/// </summary>
    public float Damage;

/// <summary>
/// If the ball touch the player, the health of the player gets deducted
/// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().TakeDamage(Damage);
        }
    }
}
