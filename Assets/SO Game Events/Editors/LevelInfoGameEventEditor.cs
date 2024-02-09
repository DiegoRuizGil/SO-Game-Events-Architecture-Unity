#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(LevelInfoEvent))]
    public class LevelInfoGameEventEditor : BaseGameEventEditor<LevelInfo, LevelInfoEvent> { }
}
#endif