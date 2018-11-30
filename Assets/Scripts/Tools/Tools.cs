using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.Debug;

public static class ListVector2Extensions
{
    public static bool TempBoardHere = false;
    public static void AddIfNotChecking(this List<Vector2> CurrentList, Vector2 Destination, Vector2 Origin, PieceColor MovingColor)
    {
        Board TempBoard = Object.Instantiate(GameObject.Find("CurrentBoard")).GetComponent<Board>();
        TempBoardHere = true;
        TempBoard.GetTileByPos(Origin).ContainedPiece.ContainingTile = TempBoard.GetTileByPos(Destination);
        if (!TempBoard.KingInCheck(MovingColor))
            CurrentList.Add(Destination);
        TempBoardHere = false;
        Object.DestroyImmediate(TempBoard.gameObject);
    }
}