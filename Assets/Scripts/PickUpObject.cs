using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts{
    public class PickupDropObjects : MonoBehaviour
    {
        private bool isPickUpAllowed;
        private GameObject objectToGrab;
        private Inventory inventory;

        void Update () {
            if (isPickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        private void Start()
        {
            inventory = GetComponent<Inventory>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ingredient>() != null)
            {
                isPickUpAllowed = true;
                objectToGrab = collision.gameObject;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Ingredient>() != null)
            {
                isPickUpAllowed = false;
                objectToGrab = null;
            }
        }

        void PickUp()
        {
            // objectGrabTransform.Grab();
            if (objectToGrab != null)
            {
                Debug.Log("Picking allowed for : " + objectToGrab.transform);
                inventory.InsertItem(objectToGrab.GetComponent<Ingredient>().data);
                Destroy(objectToGrab);
            }
        }
    }
}
