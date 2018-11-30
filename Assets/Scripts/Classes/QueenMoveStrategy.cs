using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Piece;

public class QueenMoveStrategy : IMoveStrategy
{
    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        return new RookMoveStrategy().GetAvailableTiles(Origin, MovingColor).Concat(new BishopMoveStrategy().GetAvailableTiles(Origin, MovingColor)).ToList();
    }

    public void Move(Tile Destination)
    {
    }

    public List<Vector2> UnsafeGetAvailableTiles(Vector2 Origin, PieceColor MovingColor)
    {
        return new RookMoveStrategy().UnsafeGetAvailableTiles(Origin, MovingColor).Concat(new BishopMoveStrategy().UnsafeGetAvailableTiles(Origin, MovingColor)).ToList();
    }
    #endregion
}
