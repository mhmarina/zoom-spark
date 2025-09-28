using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;

/// <summary>
/// Class intended to work with grid layout groups to create an image based health bar
/// </summary>
public class HealthDisplay : MonoBehaviour, IObserver
{
    public GameObject healthDisplayImage = null;
    private List<GameObject> heartList = new List<GameObject>();
    private LivesManager lm;

    void Start()
    {
        lm = LivesManager.Instance;
        ((IObservable)lm).RegisterObserver(this);

        // Instantiate hearts/ object pool
        for (int i = 0; i < lm.numLives; i++)
        {
            GameObject heart = Instantiate(healthDisplayImage, transform);
            heartList.Add(heart);
        }
        SetChildImageNumber(lm.numLives);
    }
    private void SetChildImageNumber(int number)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            heartList[i].SetActive(i < number);
        }
    }

    public void OnEventRaised()
    {
        Debug.Log(lm.numLives);
        SetChildImageNumber(lm.numLives);
    }
}
