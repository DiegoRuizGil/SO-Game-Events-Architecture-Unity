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
