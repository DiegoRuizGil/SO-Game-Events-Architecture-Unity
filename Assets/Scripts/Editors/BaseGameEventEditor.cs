using UnityEngine;
using UnityEditor;

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
