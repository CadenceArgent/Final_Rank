using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Board;
using static PieceColor;
using static Player;

public class PawnMoveStrategy : IMoveStrategy
{
    private bool HasMoved = true;

    public List<Vector2> GetAvailableTiles(Vector2 Origin)
    {
        List<Vector2> ret = new List<Vector2>();
        int multiplier = LocalPlayer.ControlledColor == White ? 1 : -1;
        Vector2 Destination = Origin + new Vector2(1 * multiplier, 0);
        if (Current.GetTileByPos(Destination).ContainedPiece == null)
        {
            ret.Add(Destination);
            Destination = Origin + new Vector2(2 * multiplier, 0);
            if (!HasMoved && Current.GetTileByPos(Destination).ContainedPiece == null)
            {
                ret.Add(Destination);
            }
        }
        Destination = Origin + new Vector2(1 * multiplier, 1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != LocalPlayer.ControlledColor)
        {
            ret.Add(Destination);
        }
        Destination = Origin + new Vector2(1 * multiplier, -1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != LocalPlayer.ControlledColor)
        {
            ret.Add(Destination);
        }
        return ret;
    }
}