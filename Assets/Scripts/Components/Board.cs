using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    #region Properties
    public static Board Current { get { return GameObject.Find("CurrentBoard").GetComponent<Board>(); } }
    public List<Tile> Tiles { get { return Current.GetComponentsInChildren<Tile>().ToList(); } }
    public GameObject TilePrefab;
    public GameObject TilePrefabSlow;
    public GameObject PawnPrefab;
    #endregion

    #region Unity Methods
    private void Start()
    {
        int i = 0;
        while (i < 64)
        {
            Vector2 position = new Vector2(i / 8, i % 8);
            GameObject generatedTile = Instantiate(TilePrefab, new Vector3(position.x, 0, position.y), Quaternion.identity, Current.transform);
            generatedTile.transform.Rotate(new Vector3(-90, 0, 0));
            generatedTile.GetComponent<Tile>().Position = position;
            if (i / 8 == 1 || i / 8 == 6)
            {
                GameObject generatedPiece = Instantiate(PawnPrefab, generatedTile.transform);
                generatedPiece.transform.localPosition = new Vector3(-0.5f, 0.5f, 0);
                generatedPiece.transform.localRotation = new Quaternion(0, 0, 0, 0);
                generatedPiece.GetComponent<Piece>().MovementType = new PawnMoveStrategy();
                generatedPiece.GetComponent<Piece>().Color = i / 8 == 1 ? PieceColor.White : PieceColor.Black;
            }
            i++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Piece.SelectedPiece.GetReachableTiles().ForEach(e => Debug.Log(e));
        }
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