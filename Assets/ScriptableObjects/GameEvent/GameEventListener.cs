using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // Referenced from Ryan Hipple: Game Architecture with Scriptable Objects 
    // Observable pattern (Subscriber to GameEvent)

    public GameEvent GameEvent;
    public UnityEvent Response;

    private void OnEnable()
    {
        GameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        GameEvent.UnregisterListener(this);
    }
    public void OnEventRaised()
    {
        Response.Invoke();
    }
}