using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public PlayerFeet playerFeet;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
    }
}
