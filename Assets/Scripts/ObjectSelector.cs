using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectSelector : MonoBehaviour
    {
        [SerializeField] private Texture2D interactCursor;

        private GameObject selectedObject;
        private Vector3 mousePos;
        private Vector2 mousePos2D;
        void Update()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);

            // Hover detection
            RaycastHit2D hoverHit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hoverHit && hoverHit.collider.GetComponent<ISelectable>() != null)
            {
                Cursor.SetCursor(interactCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
            }

            // Left mouse button click
            if (Input.GetMouseButtonDown(0)) 
            {
                if(selectedObject == null)
                {
                    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                    if (hit)
                    {
                        GameObject test = hit.collider.gameObject;
                        ISelectable s = test.GetComponent<ISelectable>();
                        if (s != null)
                        {
                            selectedObject = test;
                            s.isSelected = true;
                        }
                    }
                }
                else
                {
                    //Debug.Log("Deselect");
                    selectedObject.GetComponent<ISelectable>().isSelected = false;
                    selectedObject = null;
                } // deselect
            }

            // drag
            if(selectedObject != null)
            {
                selectedObject.transform.position = mousePos2D;
            }
        }
    }
}
