using GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    [Header("UI Dependencies")]
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _submitButton;
    
    [Header("Events")]
    [SerializeField] private StringEvent _onNameChanged;

    private void OnEnable()
    {
        if (_submitButton != null)
            _submitButton.onClick.AddListener(InvokeNameChangedEvent);
    }

    private void OnDisable()
    {
        if (_submitButton != null)
            _submitButton.onClick.RemoveAllListeners();
    }

    private void InvokeNameChangedEvent()
    {
        string newName = _inputField.text;
        if (!string.IsNullOrEmpty(newName))
        {
            _onNameChanged.Raise(newName);
            _inputField.text = string.Empty;
        }
    }
}
