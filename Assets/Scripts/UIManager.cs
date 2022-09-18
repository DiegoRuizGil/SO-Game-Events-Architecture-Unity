using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI points;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI pruebaText;

    public void UpdatePoints(int amount)
    {
        points.text = amount.ToString();
    }

    public void DisplayName(LevelInfo levelInfo)
    {
        levelName.text = levelInfo.levelName;
    }

    public void PruebaText(PruebaSO pruebaSO)
    {
        pruebaText.text = pruebaSO.texto;
    }
}
