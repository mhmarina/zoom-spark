using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class intended to work with grid layout groups to create an image based health bar
/// </summary>
public class HealthDisplay : MonoBehaviour
{
    public GameObject healthDisplayImage = null;

    public int maximumNumberToDisplay = 3;

    void Start()
    {
        SetChildImageNumber(3);
    }
    private void SetChildImageNumber(int number)
    {
        if (healthDisplayImage != null)
        {
            if (maximumNumberToDisplay >= number)
            {
                for (int i = 0; i < number; i++)
                {
                    Instantiate(healthDisplayImage, transform);
                }
            }
        }
    }
}
