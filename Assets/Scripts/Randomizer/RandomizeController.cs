using GameEvents;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeController : MonoBehaviour
{
    [Header("UI Dependencies")]
    [SerializeField] private Button _randomizeButton;
    
    [Header("Events")]
    [SerializeField] private VoidEvent _onRandomizeCharacter;

    private void OnEnable()
    {
        if (_randomizeButton != null)
            _randomizeButton.onClick.AddListener(InvokeRandomizeEvent);
    }

    private void OnDisable()
    {
        if (_randomizeButton != null)
            _randomizeButton.onClick.RemoveAllListeners();
    }

    private void InvokeRandomizeEvent() => _onRandomizeCharacter.Raise();
}
