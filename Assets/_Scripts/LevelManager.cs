using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private LevelData _levelData;

    [SerializeField] private GameObject _gameBoard;
    [SerializeField] private GameObject _tilePrefab;

    [SerializeField] private GameObject _hintsBoard;
    [SerializeField] private GameObject _hintPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        FileManager.OnLevelLoadComplete += HandleLevelGeneration;
    }

    private void OnDisable()
    {
        FileManager.OnLevelLoadComplete -= HandleLevelGeneration;
    }
    private void HandleLevelGeneration(LevelData levelData)
    {
        _levelData = levelData;

        GenerateLevel(_levelData);
    }

    private void GenerateLevel(LevelData ld)
    {
        double sqr = Math.Sqrt(ld.GetLevel().Length);
        int width = (int)sqr;

        int[] tileNumbers = ld.GetLevel();
        int[] visibleNumbers = ld.GetVisible();

        int boardWidthInPixels = 1800;
        
        _gameBoard.GetComponent<RectTransform>().sizeDelta = new Vector2(boardWidthInPixels, boardWidthInPixels);
        _gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(boardWidthInPixels / width, boardWidthInPixels / width);

        int tileCounter = 0;
        for(int row = 0; row < width; row++)
        {
            for (int col = 0; col < width; col++) 
            {
                GameObject tile = Instantiate(_tilePrefab, _gameBoard.transform);
                //tile.GetComponent<RectTransform>().sizeDelta = new Vector2(boardWidthInPixels / width, boardWidthInPixels / width);
                tile.GetComponent<Tile>().SetTileNumber(tileNumbers[tileCounter]);
                tile.GetComponent<Tile>().SetVisible(visibleNumbers[tileCounter] == 1);
                if (visibleNumbers[tileCounter] == 1)
                {
                    tile.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = tileNumbers[tileCounter].ToString();
                }
                tileCounter++;
            }
        }

        for (int k = 0; k < ld.GetHints().Count; k++)
        {
            GameObject hint = Instantiate(_hintPrefab, _hintsBoard.transform);
            //hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(k * 100));
            hint.GetComponent<TMPro.TextMeshProUGUI>().text = ld.GetHints()[k];
        }
        _hintPrefab.SetActive(false);
        _tilePrefab.SetActive(false);
    }
}
