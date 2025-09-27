using Assets.Scripts.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts{
    public class ObjectInteractor : MonoBehaviour
    {
        private bool isInteractionAllowed;
        private GameObject interactableObject;

        void Update () {
            if (isInteractionAllowed && Input.GetKeyDown(KeyCode.E))
            {
                interactableObject.GetComponent<IInteractable>().Interact();
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            IInteractable ing = collision.gameObject.GetComponent<IInteractable>();
            if (ing != null)
            {
                isInteractionAllowed = true;
                interactableObject = collision.gameObject;
                ing.onPlayerEnter();
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            IInteractable ing = collision.gameObject.GetComponent<IInteractable>();
            if (ing != null)
            {
                isInteractionAllowed = false;
                interactableObject = null;
                ing.onPlayerExit();
            }
        }
    }
}
