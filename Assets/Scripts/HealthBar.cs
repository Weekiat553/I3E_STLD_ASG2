/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: HealthBar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /// <summary>
    /// UI slider
    /// </summary>
    public Slider slider;

    /// <summary>
    /// Function to set Max Health
    /// </summary>
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health; // Slider's max value
        slider.value = health; // slider  min value

    }
    /// <summary>
    /// Set current health
    /// </summary>
    public void SetHealth(float health)
    {
        slider.value = health; // slider value is health


    }
}
