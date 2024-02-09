#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(IntEvent))]
    public class IntGameEventEditor : BaseGameEventEditor<int, IntEvent> { }
}
#endif