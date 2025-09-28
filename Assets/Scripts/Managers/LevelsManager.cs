using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] List<LevelData> levels = new List<LevelData>();
    public static LevelsManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void CompleteLevel(int index)
    {
        if(index < levels.Count)
        {
            levels[index].completed = true;
        }
    }

    public void UnlockLevel(int index)
    {
        if (index < levels.Count)
        {
            levels[index].locked = false;
        }
    }
}
