using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameController : MonoBehaviour, IRandomizable
{
    [Header("UI Dependencies")]
    [SerializeField] private TextMeshProUGUI _nameText;

    private List<string> _randomNames = new List<string>
    {
        "Diego", "Cloud", "Steve", "Madeline", "Samus", "Solaire", "Zelda",
        "Link", "Mario", "Luigi", "Peach", "Claire", "Patches", "Joel",
        "Ellie", "Ash", "Ryu", "GLaDOS", "Wheatley", "Chell", "Gordon"
    };
    
    public void ChangeName(string newName)
    {
        _nameText.text = newName;
    }

    public void Randomize()
    {
        _nameText.text = _randomNames[Random.Range(0, _randomNames.Count)];
    }
}
