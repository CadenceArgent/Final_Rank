using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Piece;
using static Player;

public class RookMoveStrategy : IMoveStrategy
{
    public bool CanCastle;

    public RookMoveStrategy(bool canCastle = true)
    {
        canCastle = CanCastle;
    }

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, 1), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, -1), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in RowMove(Origin, new Vector2(1, 0), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in RowMove(Origin, new Vector2(-1, 0), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        return ret;
    }

    public void Move(Vector2 Origin, Vector2 Destination, PieceColor MovingColor) => CanCastle = false;

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, 1), MovingColor))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, -1), MovingColor))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(1, 0), MovingColor))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(-1, 0), MovingColor))
            ret.Add(element);
        return ret;
    }
    #endregion

    private IEnumerable<Vector2> RowMove(Vector2 Origin, Vector2 Direction, PieceColor MovingColor)
    {
        Tile currentTile;
        while ((currentTile = Board.Current.GetTileByPos(Origin + Direction)) != null && currentTile.ContainedPiece == null)
        {
            yield return Origin + Direction;
            Direction.x += Direction.x > 0 ? 1 : Direction.x < 0 ? -1 : 0;
            Direction.y += Direction.y > 0 ? 1 : Direction.y < 0 ? -1 : 0;
        }
        if (currentTile != null && currentTile.ContainedPiece.Color != MovingColor)
            yield return Origin + Direction;
    }
}
