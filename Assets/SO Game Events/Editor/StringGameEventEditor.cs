#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(StringEvent))]
    public class StringGameEventEditor : BaseGameEventEditor<string, StringEvent> { }
}
#endif