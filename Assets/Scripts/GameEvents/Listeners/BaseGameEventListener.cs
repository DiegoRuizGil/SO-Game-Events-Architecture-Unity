using UnityEngine;
using UnityEngine.Events;

/*
 * T   -> type
 * E   -> Event
 * EUR -> UnityEventResponse
*/
public abstract class BaseGameEventListener<T, E, EUR> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where EUR : UnityEvent<T>
{
    [SerializeField] private E gameEvent;
    public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

    [SerializeField] private EUR unityEventResponse;

    public void OnEnable()
    {
        if (gameEvent == null)
            return;

        GameEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        if (gameEvent == null)
            return;

        GameEvent.UnregisterListener(this);
    }

    public void OnEventRaise(T item)
    {
        if (unityEventResponse != null)
        {
            unityEventResponse.Invoke(item);
        }
    }
}
