using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private int _tileNumber;
    [SerializeField] private bool _isVisible;

    public void SetTileNumber(int tileNumber)
    {
        _tileNumber = tileNumber;
    }

    public int GetTileNumber()
    {
        return _tileNumber;
    }

    public void SetVisible(bool isVisible)
    {
        _isVisible = isVisible;
    }

    public bool GetVisible()
    {
        return _isVisible;
    }
}
