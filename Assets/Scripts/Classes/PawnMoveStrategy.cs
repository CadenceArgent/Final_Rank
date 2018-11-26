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
        switch (LocalPlayer.ControlledColor)
        {
            case Black:
                if (Current.GetTileByPos(Origin + new Vector2(-1, 0)).ContainedPiece == null)
                {
                    ret.Add(Origin + new Vector2(-1, 0));
                }
                if (!HasMoved && Current.GetTileByPos(Origin + new Vector2(-2, 0)).ContainedPiece == null)
                {
                    ret.Add(Origin + new Vector2(-2, 0));
                }
                break;
            case White:
                if (Current.GetTileByPos(Origin + new Vector2(-1, 0)).ContainedPiece == null)
                {
                    ret.Add(Origin + new Vector2(-1, 0));
                }
                if (!HasMoved && Current.GetTileByPos(Origin + new Vector2(-2, 0)).ContainedPiece == null)
                {
                    ret.Add(Origin + new Vector2(-2, 0));
                }
                break;
        }
        return ret;
    }

    private bool CanEat(Vector2 From, Vector2 To)
    {
        return true;
    }
}