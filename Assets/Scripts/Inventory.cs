using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject IngredientPrefab;
    private List<GameObject> presentObjects = new List<GameObject>();
    public static Inventory Instance { get; private set; } 

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


    public class InventoryItem
    {
        public IngredientData Ingredient;
        public int Count;

        public InventoryItem(IngredientData id, int c)
        {
            Ingredient = id;
            Count = c;
        }
    }

    [NonSerialized]
    public List<InventoryItem> InventoryList = new List<InventoryItem>();

    public void InsertItem(IngredientData item)
    {
        // find in list
        int index = FindItem(item);
        if (index == -1)
        {
            // create new object
            InventoryItem it = new InventoryItem(item, 1);
            InventoryList.Add(it);
        }
        else
        {
            InventoryList[index].Count++;
        }
    }

    public int FindItem(IngredientData item)
    {
        for (int i = 0; i < InventoryList.Count; i++) 
        {
            if (InventoryList[i].Ingredient.ingredientName == item.ingredientName)
            {
                return i;
            }
        }
        return -1;
    }

    public void removeItem(IngredientData item)
    {
        int index = FindItem(item);
        if (index != -1)
        {
            InventoryList[index].Count--;
            if (InventoryList[index].Count == 0)
            {
                InventoryList.RemoveAt(index);
            }
        }
    }

    public void InstantiateAllIngredients()
    {
        for(int i = 0; i < InventoryList.Count; i++ )
        {
            InventoryItem it = InventoryList[i];
            float spacing = 5f;
            for(int j = 0; j < it.Count; j++)
            {
                GameObject ing = Instantiate(IngredientPrefab, new Vector3((i * spacing), (spacing * j), 0), Quaternion.identity);
                ing.GetComponent<Ingredient>().SetData(it.Ingredient);
                ing.GetComponent<SpriteRenderer>().sortingOrder = 2;
                InsertInPresent(ing);
            }
        }
    }

    public void InsertInPresent(GameObject ing)
    {
        presentObjects.Add(ing);
    }

    public void DestroyAllIngredients()
    {
        for (int i = presentObjects.Count - 1; i >= 0; i--) {
            Destroy(presentObjects[i].gameObject);
        }
    }

    public void toString()
    {
        Debug.Log("---------------------------");
        Debug.Log($"There are {InventoryList.Count} unique items in the inventory");
        for (int i = 0; i < InventoryList.Count; i++)
        {
            Debug.Log($"{InventoryList[i].Ingredient.ingredientName}, count: {InventoryList[i].Count}");
        }
    }
}
