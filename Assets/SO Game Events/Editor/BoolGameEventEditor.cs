#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(BoolEvent))]
    public class BoolGameEventEditor : BaseGameEventEditor<bool, BoolEvent> { }
}
#endif