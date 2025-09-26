using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public PlayerFeet playerFeet;
    public GameObject CraftingCanvas;
    public GameObject GameIngredients;

    private Rigidbody2D rb;
    private Inventory inventory;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        inventory = this.GetComponent<Inventory>(); 
    }

    void Update()
    {
        float mv = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + mv, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - mv, transform.position.y);
        }
        if (playerFeet.isGrounded &&
            Input.GetKeyDown(KeyCode.Space))
        {
            // jump
            rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
        }
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
        inventory.InstantiateAllIngredients();
    }

    void UnCraft() {
        CraftingCanvas.SetActive(false);
        GameIngredients.SetActive(true);
        inventory.DestroyAllIngredients();
    }
}
