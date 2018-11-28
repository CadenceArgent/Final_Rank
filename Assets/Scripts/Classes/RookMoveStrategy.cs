using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Piece;
using static Player;

public class RookMoveStrategy : IMoveStrategy
{
    public bool CanCastle = true;

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin)
    {
        List<Vector2> ret = new List<Vector2>();
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, 1)))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(0, -1)))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(1, 0)))
            ret.Add(element);
        foreach (Vector2 element in RowMove(Origin, new Vector2(-1, 0)))
            ret.Add(element);
        return ret;
    }

    public void Move(Tile Destination)
    {
        CanCastle = false;
    }
    #endregion

    private IEnumerable<Vector2> RowMove(Vector2 Origin, Vector2 Direction)
    {
        Tile currentTile;
        while ((currentTile = Board.Current.GetTileByPos(Origin + Direction)) != null && currentTile.ContainedPiece == null)
        {
            yield return Origin + Direction;
            Direction.x += Direction.x > 0 ? 1 : Direction.x < 0 ? -1 : 0;
            Direction.y += Direction.y > 0 ? 1 : Direction.y < 0 ? -1 : 0;
        }
        if (currentTile != null && currentTile.ContainedPiece.Color != LocalPlayer.ControlledColor)
            yield return Origin + Direction;
    }
}
