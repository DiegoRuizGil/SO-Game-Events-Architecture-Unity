using GameEvents;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeController : MonoBehaviour
{
    [Header("UI Dependencies")]
    [SerializeField] private Button _randomizeButton;
    
    [Header("Events")]
    [SerializeField] private VoidEvent _onRandomizeCharacter;

    private BoolListener _listener;

    private void OnEnable()
    {
        _listener.AddAction(Hola);
        _listener.RemoveAction(Hola);
        _listener.RemoveAllActions();
        
        if (_randomizeButton != null)
            _randomizeButton.onClick.AddListener(InvokeRandomizeEvent);
    }

    private void Hola(bool value)
    {
        
    }

    private void OnDisable()
    {
        if (_randomizeButton != null)
            _randomizeButton.onClick.RemoveAllListeners();
    }

    private void InvokeRandomizeEvent() => _onRandomizeCharacter.Raise();
}
