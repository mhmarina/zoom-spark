using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectSelector : MonoBehaviour
    {
        private GameObject selectedObject;

        private Vector3 mousePos;
        private Vector2 mousePos2D;
        void Update()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);

            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                if(selectedObject == null)
                {
                    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                    if (hit)
                    {
                        GameObject test = hit.collider.gameObject;
                        Debug.Log(test.name);
                        ISelectable s = test.GetComponent<ISelectable>();
                        if (s != null)
                        {
                            selectedObject = test;
                            s.isSelected = true;
                            Debug.Log("Selected: " + selectedObject.name);
                        }
                    }
                }
                else
                {
                    Debug.Log("Deselect");
                    selectedObject.GetComponent<ISelectable>().isSelected = false;
                    selectedObject = null;
                } // deselect
            }

            // drag
            if(selectedObject != null)
            {
                selectedObject.GetComponent<Rigidbody2D>().position = mousePos2D;
            }
        }
    }
}
