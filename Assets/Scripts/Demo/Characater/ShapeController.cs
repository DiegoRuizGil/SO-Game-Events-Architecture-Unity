using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeController : MonoBehaviour, IRandomizable
{
    [Header("UI Images")]
    [SerializeField] private Image _shapeImage;
    [SerializeField] private Image _faceImage;
    
    [Header("Sprites")]
    [SerializeField] private List<Sprite> _shapes;
    [SerializeField] private List<Sprite> _reactionFaces;
    [SerializeField] private Sprite _deadFace;

    private Sprite _faceBeforeDeath;

    private void Start()
    {
        _faceBeforeDeath = _faceImage.sprite;
    }
    
    public void Randomize()
    {
        if (_shapeImage == null) return;
        
        _shapeImage.sprite = _shapes[Random.Range(0, _shapes.Count)];
        _faceBeforeDeath = _reactionFaces[Random.Range(0, _reactionFaces.Count)];
        if (_faceImage.sprite != _deadFace)
            _faceImage.sprite = _faceBeforeDeath;
    }

    public void OnDeathEvent(bool isDead)
    {
        if (isDead)
        {
            _faceBeforeDeath = _faceImage.sprite;
            _faceImage.sprite = _deadFace;
        }
        else
        {
            _faceImage.sprite = _faceBeforeDeath;
        }
    }
}