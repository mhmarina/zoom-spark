using Assets.Scripts.Managers;
using UnityEngine;

public class ResetOnFall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float HeightThreshold;
    void Update()
    {
        if(transform.position.y < HeightThreshold)
        {
            UIManager.Instance.LossScreen();
        }
    }
}
