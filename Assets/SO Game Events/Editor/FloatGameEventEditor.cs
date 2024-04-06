#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(FloatEvent))]
    public class FloatGameEventEditor : BaseGameEventEditor<float, FloatEvent> { }
}
#endif