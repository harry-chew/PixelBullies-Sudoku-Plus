using UnityEngine;

public class SelectableTile : MonoBehaviour
{
    public void SelectTile()
    {
        SelectionManager.Instance.SetSelectedTile(this.GetComponent<Tile>());
    }
}
