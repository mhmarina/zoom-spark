using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts{
    public class PickupDropObjects : MonoBehaviour
    {
        private bool isPickUpAllowed;
        private GameObject objectToGrab;

        void Update () {
            if (isPickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Ingredient ing = collision.gameObject.GetComponent<Ingredient>();
            if (ing != null)
            {
                isPickUpAllowed = true;
                objectToGrab = collision.gameObject;
                ing.onPlayerEnter();
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            Ingredient ing = collision.gameObject.GetComponent<Ingredient>();
            if (ing != null)
            {
                isPickUpAllowed = false;
                objectToGrab = null;
                ing.onPlayerExit();
            }
        }

        void PickUp()
        {
            if (objectToGrab != null)
            {
                //Debug.Log("Picking allowed for : " + objectToGrab.transform);
                Inventory.Instance.InsertItem(objectToGrab.GetComponent<Ingredient>().data.ingredientName, objectToGrab);
                objectToGrab.SetActive(false);
            }
        }
    }
}
