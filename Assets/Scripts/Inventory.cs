using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
}
