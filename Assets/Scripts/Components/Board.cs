using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    #region Porperties
    public static Board Current { get { return GameObject.Find("CurrentBoard").GetComponent<Board>(); } }
    public List<Tile> Tiles { get { return Current.GetComponentsInChildren<Tile>().ToList(); } }
    public GameObject PrefabWhite;
    public GameObject PrefabBlack;
    public GameObject PrefabSlowWhite;
    public GameObject PrefabSlowBlack;
    #endregion

    #region Unity Methods
    private void Start()
    {

    }

    private void Update()
    {

    }
    #endregion

    #region Methods
    public Tile GetTileByPos(Vector2 position)
    {
        return Current.Tiles.Any(e => e.Position == position) ? Current.Tiles.Single(e => e.Position == position) : null;
    }

    public List<Piece> GetPiecesByColor(PieceColor color)
    {
        List<Piece> ret = new List<Piece>();
        foreach (Tile element in Current.Tiles)
        {
            if (element.ContainedPiece.Color == color)
            {
                ret.Add(element.ContainedPiece);
            }
        }
        return ret;
    }
    #endregion
}