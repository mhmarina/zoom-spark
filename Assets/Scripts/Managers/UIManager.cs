using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject CraftingCanvas;
        public GameObject GameIngredients;
        public GameObject Player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (CraftingCanvas.activeInHierarchy)
                {
                    // pull down
                    UnCraft();
                }
                else
                {
                    // pull up
                    Craft();
                }
            }
        }
        void Craft()
        {
            CraftingCanvas.SetActive(true);
            GameIngredients.SetActive(false);
            Player.SetActive(false);
            Inventory.Instance.ShowAllIngredients();
        }

        void UnCraft()
        {
            CraftingCanvas.SetActive(false);
            GameIngredients.SetActive(true);
            Player.SetActive(true);
            Inventory.Instance.HideAllIngredients();
        }
    }
}
