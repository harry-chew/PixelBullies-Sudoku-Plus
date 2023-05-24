using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileGuess : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = this.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void SetTileGuess()
    {
        if (!SelectionManager.Instance.GetSelectedTile()) return;
        int tileNumber = SelectionManager.Instance.GetSelectedTile().GetTileNumber();
        textMesh.text = tileNumber.ToString();
        textMesh.color = Color.red;
    }
}
