using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Piece;
using static Player;

public class BishopMoveStrategy : IMoveStrategy
{
    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, 1)))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, 1)))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(1, -1)))
            ret.Add(element);
        foreach (Vector2 element in DiagonalMove(Origin, new Vector2(-1, -1)))
            ret.Add(element);
        return ret;
    }

    public void Move(Tile Destination)
    {
    }
    #endregion

    private IEnumerable<Vector2> DiagonalMove(Vector2 Origin, Vector2 CornerDirection)
    {
        Tile currentTile;
        while ((currentTile = Board.Current.GetTileByPos(Origin + CornerDirection)) != null && currentTile.ContainedPiece == null)
        {
            yield return Origin + CornerDirection;
            CornerDirection.x += CornerDirection.x > 0 ? 1 : -1;
            CornerDirection.y += CornerDirection.y > 0 ? 1 : -1;
        }
        if (currentTile != null && currentTile.ContainedPiece.Color != LocalPlayer.ControlledColor)
            yield return Origin + CornerDirection;
    }
}
