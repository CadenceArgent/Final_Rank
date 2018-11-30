using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Piece;
using static Player;

public class KingMoveStrategy : IMoveStrategy
{
    public bool CanCastle = true;

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        List<Vector2> ToCheck = new List<Vector2>
        {
            new Vector2(0, 1),
            new Vector2(0, -1),
            new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(-1, 0),
            new Vector2(-1, -1)
        };
        Tile CurrentTile;
        foreach (Vector2 direction in ToCheck)
            if ((CurrentTile = Board.Current.GetTileByPos(Origin + direction)) != null && CurrentTile.ContainedPiece?.Color != MovingColor)
                ret.AddIfNotChecking(CurrentTile.Position, Origin, MovingColor);
        return ret;
    }

    public void Move(Tile Destination) => CanCastle = false;

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        List<Vector2> ToCheck = new List<Vector2>
        {
            new Vector2(0, 1),
            new Vector2(0, -1),
            new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(1, -1),
            new Vector2(-1, 1),
            new Vector2(-1, 0),
            new Vector2(-1, -1)
        };
        Tile CurrentTile;
        foreach (Vector2 direction in ToCheck)
            if ((CurrentTile = Board.Current.GetTileByPos(Origin + direction)) != null && CurrentTile.ContainedPiece?.Color != MovingColor)
                ret.Add(CurrentTile.Position);
        return ret;
    }
    #endregion
}
