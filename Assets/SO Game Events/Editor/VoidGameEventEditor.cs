#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(VoidEvent))]
    public class VoidGameEventEditor : BaseGameEventEditor<Void, VoidEvent> { }
}
#endif