/*
    This script is part of the SO Game Events Architecture Project.
    You are free to use, modify, and distribute the code as you want.
    Credit is not required, but it is always appreciated.

    Author: Diego Ruiz Gil
    https://github.com/DiegoRuizGil/SO-Game-Events-Architecture-Unity
*/

using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    /*
     * T   -> Type
     * E   -> Event
     * EUR -> UnityEventResponse
     */

    public abstract class BaseGameEventListener<T, E, EUR> : MonoBehaviour, IGameEventListener<T>
        where E : BaseGameEvent<T> where EUR : UnityEvent<T>
    {
        [SerializeField] private E gameEvent;

        public E GameEvent
        {
            get { return gameEvent; }
            set { gameEvent = value; }
        }

        [SerializeField] protected EUR unityEventResponse;

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
        
        public void AddAction(UnityAction<T> call)
        {
            unityEventResponse.AddListener(call);
        }

        public void RemoveAction(UnityAction<T> call)
        {
            unityEventResponse.RemoveListener(call);
        }

        public virtual void RemoveAllActions()
        {
            unityEventResponse.RemoveAllListeners();
        }
    }
}
