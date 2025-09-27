using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Assets.Scripts;
using Assets.Scripts.Interfaces;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour, IObservable
{
    public float displaySpacing;
    public float yPlacing;

    public static Inventory Instance { get; private set; }

    [NonSerialized]
    public Dictionary<string, List<GameObject>> InventoryList = new Dictionary<string, List<GameObject>>();
    private List<IObserver> _observers = new List<IObserver>();
    public List<IObserver> Observers { get { return _observers; } }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
    }

    public void InsertItem(string item, GameObject gameObj, Vector2 pos = new Vector2())
    {
        gameObj.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // find in list
        bool found = FindItem(item);
        if (!found)
        {
            InventoryList.Add(item, new List<GameObject>());
        }

        if (pos == Vector2.zero)
        {
            int index = InventoryList.Keys.Count;
            Vector3 screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2f, Camera.main.nearClipPlane));
            pos = new Vector2(screenLeft.x + displaySpacing * index, yPlacing);
        }

        gameObj.transform.position = pos;
        gameObj.transform.parent = null;
        InventoryList[item].Add(gameObj);
        ((IObservable)this).Raise();
    }

    public bool FindItem(string item)
    {
        return InventoryList.ContainsKey(item);
    }

    public void removeItem(string item, GameObject obj = null)
    {
        bool found = FindItem(item);
        List<GameObject> itemList = InventoryList[item];
        if (found)
        {
            if(obj == null)
            {
                // just remove the first one
                itemList.RemoveAt(0);
            }
            else { itemList.Remove(obj); }

            if (itemList.Count == 0)
            {
                InventoryList.Remove(item);
            }
        }
        ((IObservable)this).Raise();
    }

    public void ShowAllIngredients()
    {
        foreach(string key in InventoryList.Keys)
        {
            List<GameObject> it = InventoryList[key];
            for (int j = 0; j < it.Count; j++)
            {
                it[j].SetActive(true);
            }
        }
    }

    public void HideAllIngredients()
    {
        foreach (string key in InventoryList.Keys)
        {
            List<GameObject> it = InventoryList[key];
            for (int j = 0; j < it.Count; j++)
            {
                it[j].SetActive(false);
            }
        }
    }

    public void toString()
    {
        Debug.Log("---------------------------");
        Debug.Log($"There are {InventoryList.Count} unique items in the inventory");

        foreach (string key in InventoryList.Keys)
        {
            List<GameObject> it = InventoryList[key];
            Debug.Log($"{key}, count: {it.Count}");
        }
    }
}
