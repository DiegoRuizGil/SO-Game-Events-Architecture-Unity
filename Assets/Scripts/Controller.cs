using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private LevelInfo levelInfo;
    [SerializeField] private PruebaSO pruebaSO;

    [Header("Game Events")]
    [SerializeField] private VoidEvent onSpacePressed;
    [SerializeField] private IntEvent pointsUpdate;
    [SerializeField] private LevelInfoEvent levelNameUpdate;
    [SerializeField] private PruebaSOEvent pruebaEvent;

    private int points = 0;

    private void Start()
    {
        levelInfo.levelName = "Default name";
    }

    void Update()
    {
        Actions();
    }

    private void Actions()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //onSpacePressed.Raise();

            points++;
            pointsUpdate.Raise(points);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            levelNameUpdate.Raise(levelInfo);
            pruebaEvent.Raise(pruebaSO);
        }
    }
}
