using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float followDelay = 1.0f;
    [SerializeField] float followSpeed = 5.0f;
    [SerializeField] float cursorFollowSpeed = 1.0f;

    private Transform playerTransform;

    void Start()
    {
        if(Player != null)
        {
            playerTransform = Player.transform;
        }
    }

    void Update()
    {
        Vector3 targetPos;

        if (Player != null && Player.activeInHierarchy)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);
            if (distance >= followDelay)
            {
                targetPos = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
            }
        }
        // follow cursor if player is inactive
        else
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, cursorFollowSpeed * Time.deltaTime);
        }
    }
}