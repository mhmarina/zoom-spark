using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Classes;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ingredient : MonoBehaviour, ISelectable
    {
        public bool isSelected { get; set; }

        [SerializeField] public GameObject InteractionUI;
        [SerializeField] public IngredientData data;

        SpriteRenderer sr;

        void Start()
        {
            // populate data
            SetData(data);
        }

        public void SetData(IngredientData newData)
        {
            data = newData;
            this.name = data.ingredientName;
            if (sr == null) sr = GetComponent<SpriteRenderer>();
            sr.sprite = data.sprite;
        }

        public void onPlayerEnter()
        {
            Debug.Log("player entered");
            InteractionUI.SetActive(true);
        }

        public void onPlayerExit()
        {
            Debug.Log("player exited");
            InteractionUI.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!isSelected) return;
            Debug.Log("Collided!");
            // check if I collided with another Ingredient
            // if so check my recipes and see if the other object appears
            // if so destroy both objects and instantiate result
            Ingredient secondIngredient = collision.gameObject.GetComponent<Ingredient>();
            if (secondIngredient != null)
            {
                // check if second is in this ingredient's list of recipes
                foreach (RecipeComponent recipe in data.recipes)
                {
                    if (recipe.secondIngredient.ingredientName == secondIngredient.data.ingredientName)
                    {
                        IngredientData resultRecipe = recipe.result;
                        Vector3 pos = transform.position;
                        GameObject resultObj = Instantiate(this.gameObject);

                        resultObj.name = resultRecipe.ingredientName;
                        resultObj.GetComponent<Ingredient>().SetData(resultRecipe);

                        Destroy(gameObject);
                        Destroy(collision.gameObject);

                        // update inventory:
                        Inventory i = Inventory.Instance;
                        i.removeItem(data.ingredientName, gameObject);
                        i.removeItem(secondIngredient.data.ingredientName, secondIngredient.gameObject);
                        i.InsertItem(resultRecipe.ingredientName, resultObj, pos);
                    }
                }
            }

        }
    }
}
