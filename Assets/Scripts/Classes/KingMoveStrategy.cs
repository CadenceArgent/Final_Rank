using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using static Piece;

public class KingMoveStrategy : IMoveStrategy
{
    public bool CanCastle = true;

    #region IMoveStrategy
    public List<Vector2> GetAvailableTiles(Vector2 Origin)
    {
        List<Vector2> ret = new List<Vector2>();
        Tile CurrentTile;
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(0, 1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(0, -1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(1, 1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(1, 0))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(1, -1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(-1, 1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(-1, 0))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        if ((CurrentTile = Board.Current.GetTileByPos(Origin + new Vector2(-1, -1))) != null && CurrentTile.ContainedPiece?.Color != LocalPlayer.ControlledColor)
            ret.Add(CurrentTile.Position);
        return ret;
    }

    public void Move(Tile Destination)
    {
        CanCastle = false;
    }
    #endregion
}
