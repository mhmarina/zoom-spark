using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float displaySpacing;
    public float yPlacing;

    public static Inventory Instance { get; private set; }

    public class InventoryItem
    {
        public string Ingredient;
        public List<GameObject> gameObjects;
        public int Count
        {
            get
            {
                return gameObjects.Count;
            }
        }

        public InventoryItem(String ingredientName)
        {
            Ingredient = ingredientName;
            gameObjects = new List<GameObject>();
        }
    }

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


    [NonSerialized]
    public List<InventoryItem> InventoryList = new List<InventoryItem>();

    public void InsertItem(string item, GameObject gameObj, Vector2 pos = new Vector2())
    {
        gameObj.GetComponent<SpriteRenderer>().sortingOrder = 2;
        // find in list
        int index = FindItem(item);
        InventoryItem it;
        if (index == -1)
        {
            it = new InventoryItem(item);
            InventoryList.Add(it);
        }
        else
        {
            it = InventoryList[index];
        }
        if (pos == new Vector2())
        {
            pos = new Vector2(displaySpacing, yPlacing);
        }
        gameObj.transform.position = pos;
        gameObj.transform.parent = null;
        it.gameObjects.Add(gameObj);
    }

    public int FindItem(string item)
    {
        for (int i = 0; i < InventoryList.Count; i++) 
        {
            if (InventoryList[i].Ingredient == item)
            {
                return i;
            }
        }
        return -1;
    }

    public void removeItem(string item, GameObject obj)
    {
        int index = FindItem(item);
        if (index != -1)
        {
            InventoryList[index].gameObjects.Remove(obj);
            if (InventoryList[index].Count == 0)
            {
                InventoryList.RemoveAt(index);
            }
        }
    }

    public void ShowAllIngredients()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            InventoryItem it = InventoryList[i];
            for (int j = 0; j < it.Count; j++)
            {
                InventoryList[i].gameObjects[j].SetActive(true);
            }
        }
        toString();
    }

    public void HideAllIngredients()
    {
        for (int i = InventoryList.Count - 1; i >= 0; i--)
        {
            InventoryItem it = InventoryList[i];
            for (int j = 0; j < it.Count; j++)
            {
                InventoryList[i].gameObjects[j].SetActive(false);
            }
            toString();
        }
    }

    public void toString()
    {
        Debug.Log("---------------------------");
        Debug.Log($"There are {InventoryList.Count} unique items in the inventory");
        for (int i = 0; i < InventoryList.Count; i++)
        {
            Debug.Log($"{InventoryList[i].Ingredient}, count: {InventoryList[i].Count}");
        }
    }
}
