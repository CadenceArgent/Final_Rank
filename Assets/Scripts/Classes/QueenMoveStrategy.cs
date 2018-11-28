using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Piece;

public class QueenMoveStrategy : IMoveStrategy
{
    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin)
    {
        return new RookMoveStrategy().GetAvailableTiles(Origin).Concat(new BishopMoveStrategy().GetAvailableTiles(Origin)).ToList();
    }

    public void Move(Tile Destination)
    {
    }
    #endregion
}
