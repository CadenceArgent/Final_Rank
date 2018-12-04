using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Piece;
using static PieceColor;
using static Player;

public class KingMoveStrategy : IMoveStrategy
{
    public bool CanCastle = true;

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        List<Vector2> toCheck = new List<Vector2>
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
        foreach (Vector2 direction in toCheck)
            if ((CurrentTile = Board.Current.GetTileByPos(Origin + direction)) != null && CurrentTile.ContainedPiece?.Color != MovingColor)
                ret.AddIfNotChecking(CurrentTile.Position, Origin, MovingColor);
        if (CanCastle && ((MovingColor == White && !WhitePlayer.CheckedOnce) || (MovingColor == Black && !BlackPlayer.CheckedOnce)))
        {
            //presumed towers positions
            toCheck = new List<Vector2>
            {
                MovingColor == White ? new Vector2(0, 0) : new Vector2(7, 0),
                MovingColor == White ? new Vector2(0, 7) : new Vector2(7, 7)
            };
            foreach (Vector2 RookPosition in toCheck)
            {
                Piece currentPiece = Board.Current.GetTileByPos(RookPosition).ContainedPiece;
                if (currentPiece == null)
                    continue;
                Vector2 KingDestination = new Vector2(Origin.x, Origin.y + (RookPosition.y < Origin.y ? -2 : 2));
                Vector2 TowerDestination = new Vector2(Origin.x, Origin.y + (RookPosition.y < Origin.y ? -1 : 1));
                if (currentPiece.MovementType is RookMoveStrategy && (currentPiece.MovementType as RookMoveStrategy).CanCastle && currentPiece.CanMove(TowerDestination))
                {
                    ret.AddIfNotChecking(KingDestination, Origin, MovingColor);
                }
            }
        }
        return ret;
    }

    public void Move(Vector2 Origin, Vector2 Destination, PieceColor MovingColor)
    {
        if (Mathf.Abs(Origin.y - Destination.y) == 2)
        {
            Vector2 TowerPosition = new Vector2(Origin.x, Origin.y > Destination.y ? 0 : 7);
            Vector2 TowerDestination = new Vector2(Origin.x, TowerPosition.y + (Origin.y > Destination.y ? 2 : -3));
            Board.Current.GetTileByPos(TowerPosition).ContainedPiece.ContainingTile = Board.Current.GetTileByPos(TowerDestination);
        }
        CanCastle = false;
    }

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        List<Vector2> ret = new List<Vector2>();
        List<Vector2> toCheck = new List<Vector2>
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
        foreach (Vector2 direction in toCheck)
            if ((CurrentTile = Board.Current.GetTileByPos(Origin + direction)) != null && CurrentTile.ContainedPiece?.Color != MovingColor)
                ret.Add(CurrentTile.Position);
        if (CanCastle)
        {
            //presumed towers positions
            toCheck = new List<Vector2>
            {
                MovingColor == White ? new Vector2(0, 0) : new Vector2(7, 0),
                MovingColor == White ? new Vector2(0, 7) : new Vector2(7, 7)
            };
            foreach (Vector2 RookPosition in toCheck)
            {
                Piece currentPiece = Board.Current.GetTileByPos(RookPosition).ContainedPiece;
                if (currentPiece == null)
                    continue;
                Vector2 KingDestination = new Vector2(Origin.x, Origin.y + (RookPosition.y < Origin.y ? -2 : 2));
                Vector2 TowerDestination = new Vector2(Origin.x, Origin.y + (RookPosition.y < Origin.y ? -1 : 1));
                if (currentPiece.MovementType is RookMoveStrategy && (currentPiece.MovementType as RookMoveStrategy).CanCastle && currentPiece.CanMove(TowerDestination))
                {
                    ret.Add(KingDestination);
                }
            }
        }
        return ret;
    }
    #endregion
}
