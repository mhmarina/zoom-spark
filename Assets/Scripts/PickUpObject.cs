using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts{
    public class PickupDropObjects : MonoBehaviour
    {
        private bool isPickUpAllowed;
        private GameObject objectToGrab;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update () {
            if (isPickUpAllowed && Input.GetKeyDown(KeyCode.E))
                PickUp();
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
                Destroy(objectToGrab);
            }

        }
    }
}
