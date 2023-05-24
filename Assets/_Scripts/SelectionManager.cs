using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    [SerializeField] private GameObject _numberSelectionPanel;
    [SerializeField] private GameObject _numberSelectionButtonTemplate;
    [SerializeField] private int _numberSelectionButtonCount;

    [SerializeField] private Tile selectedTile;
    [SerializeField] private int selectedNumber;

    private void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Generate();

        _numberSelectionButtonCount = 4;
    }

    private void Generate()
    {
        _numberSelectionPanel.GetComponent<GridLayoutGroup>().cellSize = _numberSelectionPanel.GetComponent<RectTransform>().sizeDelta / Mathf.Sqrt(_numberSelectionButtonCount);
        for (int i = 1; i < _numberSelectionButtonCount + 1; i++)
        {
            GameObject button = Instantiate(_numberSelectionButtonTemplate, _numberSelectionPanel.transform);
            button.GetComponent<Tile>().SetTileNumber(i);
            button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = i.ToString();
        }
        _numberSelectionButtonTemplate.SetActive(false);
    }

    public void SetSelectedTile(Tile tile)
    {
        selectedTile = tile;
        selectedNumber = tile.GetTileNumber();
    }

    public void DeselectTile()
    {
        selectedTile = null;
        selectedNumber = 0;
    }

    public Tile GetSelectedTile()
    {
        return selectedTile;
    }
}
