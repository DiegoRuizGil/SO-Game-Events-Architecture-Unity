#if UNITY_EDITOR
using UnityEditor;

namespace GameEvents
{
    [CustomEditor(typeof(PruebaSOEvent))]
    public class PruebaSOGameEventEditor : BaseGameEventEditor<PruebaSO, PruebaSOEvent> { }
}
#endif