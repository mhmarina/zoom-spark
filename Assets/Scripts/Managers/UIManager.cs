using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        public GameObject CraftingCanvas;
        public GameObject GameIngredients;
        public GameObject Player;
        public GameObject LossCanvas;
        public GameObject WinCanvas;
        public GameObject PauseScreen;
        public static UIManager Instance;

        private bool isPaused = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {   if(Player != null)
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPause();
            }
        }

        void Craft()
        {
            SnapCamera();
            CraftingCanvas.SetActive(true);
            GameIngredients.SetActive(false);
            Player.SetActive(false);
            Inventory.Instance.ShowAllIngredients();
        }

        private void SnapCamera()
        {
            // Find some position
            if (Inventory.Instance.InventoryList.Keys.Count == 0) return;
            else
            {
                string key = Inventory.Instance.InventoryList.Keys.First();
                Vector2 pos = Inventory.Instance.InventoryList[key][0].transform.position;
                Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
            }
        }

        void UnCraft()
        {
            CraftingCanvas.SetActive(false);
            GameIngredients.SetActive(true);
            Player.SetActive(true);
            Inventory.Instance.HideAllIngredients();
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void WinScreen()
        {
            WinCanvas.SetActive(true);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LossScreen()
        {
            LossCanvas.SetActive(true);
        }

        public void OnPause()
        {
            if (isPaused)
            {
                //unPause
                Time.timeScale = 1;
                PauseScreen.SetActive(false);
            }
            else { 
                Time.timeScale = 0;
                PauseScreen.SetActive(true);
            }
            isPaused = !isPaused;
        }
    }
}
