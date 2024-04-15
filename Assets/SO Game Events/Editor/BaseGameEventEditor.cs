/*
    This script is part of the SO Game Events Architecture Project.
    You are free to use, modify, and distribute the code as you want.
    Credit is not required, but it is always appreciated.

    Author: Diego Ruiz Gil
    https://github.com/DiegoRuizGil/SO-Game-Events-Architecture-Unity
*/

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace GameEvents
{
    public class BaseGameEventEditor<T, E> : Editor where E : BaseGameEvent<T>
    {
        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            E gameEvent = target as E;

            if (GUILayout.Button("Raise"))
                gameEvent.Raise(gameEvent.debugValue);
        }
    }
}
#endif
