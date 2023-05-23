using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    [SerializeField] private int[] _level;
    [SerializeField] private int[] _visible;
    [SerializeField] private List<string> _hints = new List<string>();

    public void SetLevel(int[] level)
    {
        _level = level;
    }

    public void SetVisible(int[] visible)
    {
        _visible = visible;
    }

    public void SetHints(List<string> hints)
    {
        _hints = hints;
    }

    public int[] GetLevel()
    {
        return _level;
    }

    public int[] GetVisible()
    {
        return _visible;
    }

    public List<string> GetHints()
    {
        return _hints;
    }
}
