using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float followDelay;
    [SerializeField] float followSpeed;
    
    private Transform playerTransform;

    void Start()
    {
        playerTransform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if(distance >= followDelay)
        {
            Vector3 newPos = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
