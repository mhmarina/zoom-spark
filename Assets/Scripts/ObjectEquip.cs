using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Interfaces;
using NUnit.Framework;
using UnityEngine;

public class ObjectEquip : MonoBehaviour, IObserver
{
    [SerializeField] SpriteRenderer CurrentSprite;
    public NameSprite CurrentlySelected;

    private int currIndex = -1;

    public class NameSprite
    {
        public Sprite sprite;
        public string name;
    }

    List<NameSprite> Items = new List<NameSprite>();

    void Start()
    {
        ((IObservable)Inventory.Instance).RegisterObserver(this);
        UpdateList();
    }

    void Update()
    {
        if(currIndex != -1)
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                // go right
                currIndex = Mathf.Abs((currIndex + 1) % Items.Count);
                UpdateSelection();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                // go right
                currIndex = Mathf.Abs((currIndex - 1 + Items.Count) % Items.Count);
                UpdateSelection();
            }
        }
    }

    public void OnEventRaised()
    {
        UpdateList();
    }

    void UpdateList()
    {
        if (Inventory.Instance.InventoryList.Count <= 0) return;
        Items.Clear();
        foreach(string key in Inventory.Instance.InventoryList.Keys)
        {
            GameObject g = Inventory.Instance.InventoryList[key][0];

            NameSprite ns = new NameSprite();
            ns.sprite = g.GetComponent<Ingredient>().data.sprite;
            ns.name = key;

            Items.Add(ns);
        }
        if (Items.Count > 0) {
            CurrentSprite.gameObject.SetActive(true);
            CurrentlySelected = Items[0];
            currIndex = 0;
            UpdateSelection();
        }
        else
        {
            CurrentSprite.gameObject.SetActive(false);
            currIndex = -1;
        }
    }

    void UpdateSelection()
    {
        if(currIndex < 0 || currIndex >= Items.Count) return;
        NameSprite ns = Items[currIndex];
        CurrentlySelected = ns;
        CurrentSprite.sprite = ns.sprite;
    }
}
