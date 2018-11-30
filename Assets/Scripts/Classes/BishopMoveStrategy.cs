using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Piece;
using static Player;

public class BishopMoveStrategy : IMoveStrategy
{
    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, 1), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, 1), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, -1), MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, -1),MovingColor))
            ret.AddIfNotChecking(element, Origin, MovingColor);
        return ret;
    }

    public void Move(Tile Destination)
    {
    }

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, 1),MovingColor))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, 1),MovingColor))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, -1), MovingColor))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, -1), MovingColor))
            ret.Add(element);
        return ret;
    }
    #endregion

    private IEnumerable<Vector2> DiagonalMove(Vector2 Origin, Vector2 CornerDirection,PieceColor MovingColor)
    {
        Tile currentTile;
        while ((currentTile = Board.Current.GetTileByPos(Origin + CornerDirection)) != null && currentTile.ContainedPiece == null)
        {
            yield return Origin + CornerDirection;
            CornerDirection.x += CornerDirection.x > 0 ? 1 : -1;
            CornerDirection.y += CornerDirection.y > 0 ? 1 : -1;
        }
        if (currentTile != null && currentTile.ContainedPiece.Color != MovingColor)
            yield return Origin + CornerDirection;
    }
}
