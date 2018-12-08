using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Board;
using static Piece;
using static PieceColor;
using static Player;

public class PawnMoveStrategy : IMoveStrategy
{
    private bool HasMoved = false;

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        int multiplier = MovingColor == White ? 1 : -1;
        List<Vector2> ret = new List<Vector2>();
        Vector2 Destination = Origin + new Vector2(1 * multiplier, 0);
        if (Current.GetTileByPos(Destination) != null && Current.GetTileByPos(Destination).ContainedPiece == null)
        {
            ret.AddIfNotChecking(Destination, Origin, MovingColor);
            Destination = Origin + new Vector2(2 * multiplier, 0);
            if (!HasMoved && Current.GetTileByPos(Destination).ContainedPiece == null)
            {
                ret.AddIfNotChecking(Destination, Origin, MovingColor);
            }
        }
        Destination = Origin + new Vector2(1 * multiplier, 1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != MovingColor)
        {
            ret.AddIfNotChecking(Destination, Origin, MovingColor);
        }
        Destination = Origin + new Vector2(1 * multiplier, -1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != MovingColor)
        {
            ret.AddIfNotChecking(Destination, Origin, MovingColor);
        }
        return ret;
    }

    public void Move(Vector2 Origin, Vector2 Destination, PieceColor MovingColor)
    {
        if (!ListVector2Extensions.TempBoardHere && ((Destination.x == 7 && MovingColor == White) || (Destination.x == 0 && MovingColor == Black)))
        {
            Current.PromotionUI.SetActive(true);
            Board.Current.PromotingPiece = Current.GetTileByPos(Destination).ContainedPiece;
        }
        HasMoved = true;
    }

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        int multiplier = MovingColor == White ? 1 : -1;
        Vector2 Destination = Origin + new Vector2(1 * multiplier, 0);
        if (Current.GetTileByPos(Destination) != null && Current.GetTileByPos(Destination).ContainedPiece == null)
        {
            ret.Add(Destination);
            Destination = Origin + new Vector2(2 * multiplier, 0);
            if (!HasMoved && Current.GetTileByPos(Destination).ContainedPiece == null)
            {
                ret.Add(Destination);
            }
        }
        Destination = Origin + new Vector2(1 * multiplier, 1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != MovingColor)
        {
            ret.Add(Destination);
        }
        Destination = Origin + new Vector2(1 * multiplier, -1);
        if (Current.GetTileByPos(Destination)?.ContainedPiece != null && Current.GetTileByPos(Destination).ContainedPiece.Color != MovingColor)
        {
            ret.Add(Destination);
        }
        return ret;
    }
    #endregion
}