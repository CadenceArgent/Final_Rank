using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PieceColor;

public class Board : MonoBehaviour
{
    #region Properties
    public static bool Generated = false;
    public static Board Current { get { return GameObject.Find(ListVector2Extensions.TempBoardHere ? "CurrentBoard(Clone)" : "CurrentBoard").GetComponent<Board>(); } }
    public List<Tile> Tiles { get { return GetComponentsInChildren<Tile>().ToList(); } }
    public Piece WhiteKing { get { return WhitePieces.Single(piece => piece.gameObject.name.Contains(PieceNames.King.ToString())); } }
    public Piece BlackKing { get { return BlackPieces.Single(piece => piece.gameObject.name.Contains(PieceNames.King.ToString())); } }
    public List<Piece> WhitePieces
    {
        get
        {
            List<Piece> ret = new List<Piece>();
            foreach (Tile tile in Tiles)
                if (tile.ContainedPiece != null && tile.ContainedPiece.Color == White)
                    ret.Add(tile.ContainedPiece);
            return ret;
        }
    }
    public List<Piece> BlackPieces
    {
        get
        {
            List<Piece> ret = new List<Piece>();
            int i = 0;
            foreach (Tile tile in Tiles)
            {
                if (tile.ContainedPiece != null && tile.ContainedPiece.Color == Black)
                {
                    i++;
                    ret.Add(tile.ContainedPiece);
                }
            }
            return ret;
        }
    }
    public GameObject TilePrefab;
    public GameObject TilePrefabSlow;
    public GameObject PawnPrefab;
    public GameObject BishopPrefab;
    public GameObject QueenPrefab;
    public GameObject KingPrefab;
    public GameObject KnightPrefab;
    public GameObject RookPrefab;
    #endregion

    #region Unity Methods
    private void Start()
    {
        if (Generated)
        {
            return;
        }
        List<int> Bishops = new List<int>() { 2, 5, 58, 61 };
        List<int> Queens = new List<int>() { 4, 60 };
        List<int> Kings = new List<int>() { 3, 59 };
        List<int> Knights = new List<int>() { 1, 6, 57, 62 };
        List<int> Rooks = new List<int>() { 0, 7, 56, 63 };
        List<int> Pawns = new List<int>() { 8, 9, 10, 11, 12, 13, 14, 15, 48, 49, 50, 51, 52, 53, 54, 55 };
        int i = 0;
        while (i < 64)
        {
            Vector2 position = new Vector2(i / 8, i % 8);
            GameObject generatedTile = Instantiate(TilePrefab, new Vector3(position.x, 0, position.y), Quaternion.identity, Current.transform);
            generatedTile.transform.Rotate(new Vector3(-90, 0, 0));
            generatedTile.GetComponent<Tile>().Position = position;
            if (Pawns.Contains(i))
            {
                GameObject generatedPiece = Instantiate(PawnPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Pawns.IndexOf(i) < Pawns.Count / 2 ? White : Black;
            }
            else if (Bishops.Contains(i))
            {
                GameObject generatedPiece = Instantiate(BishopPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Bishops.IndexOf(i) < Bishops.Count / 2 ? White : Black;
            }
            else if (Knights.Contains(i))
            {
                GameObject generatedPiece = Instantiate(KnightPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Knights.IndexOf(i) < Knights.Count / 2 ? White : Black;
            }
            else if (Rooks.Contains(i))
            {
                GameObject generatedPiece = Instantiate(RookPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Rooks.IndexOf(i) < Rooks.Count / 2 ? White : Black;
            }
            else if (Queens.Contains(i))
            {
                GameObject generatedPiece = Instantiate(QueenPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Queens.IndexOf(i) < Queens.Count / 2 ? White : Black;
            }
            else if (Kings.Contains(i))
            {
                GameObject generatedPiece = Instantiate(KingPrefab);
                generatedPiece.GetComponent<Piece>().ContainingTile = generatedTile.GetComponent<Tile>();
                generatedPiece.GetComponent<Piece>().Color = Kings.IndexOf(i) < Kings.Count / 2 ? White : Black;
            }
            i++;
            Generated = true;
        }
    }
    #endregion

    #region Methods
    public Tile GetTileByPos(Vector2 position) => Tiles.SingleOrDefault(e => e.Position == position);

    public bool KingInCheck(PieceColor KingColor)
    {
        if (KingColor == None)
            return false;
        else if (KingColor == White)
        {
            foreach (Piece piece in BlackPieces)
            {
                if (piece.UnsafeCanMove(WhiteKing.ContainingTile.Position))
                    return true;
            }
        }
        else
        {
            foreach (Piece piece in WhitePieces)
            {
                if (piece.UnsafeCanMove(BlackKing.ContainingTile.Position))
                    return true;
            }
        }
        return false;
    }
    #endregion
}