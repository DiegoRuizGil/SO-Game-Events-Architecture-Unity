/*
    This script is part of the SO Game Events Architecture Project.
    You are free to use, modify, and distribute the code as you want.
    Credit is not required, but it is always appreciated.

    Author: Diego Ruiz Gil
    https://github.com/DiegoRuizGil/SO-Game-Events-Architecture-Unity
*/

using System.Collections.Generic;
using UnityEngine.Events;

namespace GameEvents
{
    public class VoidListener : BaseGameEventListener<Void, VoidEvent, UnityEvent<Void>>
    {
        private readonly Dictionary<string, UnityAction<Void>> voidActions =
            new Dictionary<string, UnityAction<Void>>();
        
        public void AddAction(UnityAction call)
        {
            UnityAction<Void> voidAction = _ => call.Invoke();
            string uniqueKey = GetActionKey(call);
            
            unityEventResponse.AddListener(voidAction);
            voidActions.Add(uniqueKey, voidAction);
        }

        public void RemoveAction(UnityAction call)
        {
            string uniqueKey = GetActionKey(call);

            if (voidActions.TryGetValue(uniqueKey, out UnityAction<Void> actionToRemove))
            {
                unityEventResponse.RemoveListener(actionToRemove);
                voidActions.Remove(uniqueKey);
            }
        }

        public override void RemoveAllActions()
        {
            voidActions.Clear();
            base.RemoveAllActions();
        }

        private string GetActionKey(UnityAction call)
        {
            return $"{call.Method.Name}{call.Target.GetHashCode()}";
        }
    }
}
