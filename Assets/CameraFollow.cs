using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    
    private Transform playerTransform;

    void Start()
    {
        playerTransform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
