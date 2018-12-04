using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PieceColor;

public class Player
{
    public bool CheckedOnce = false;
    public static Player LocalPlayer = new Player();
    public static Player RemotePlayer = new Player();
    public static Player ActivePlayer { get { return LocalPlayer.Active ? LocalPlayer : RemotePlayer; } }

    public static Player WhitePlayer { get { return LocalPlayer.ControlledColor == White ? LocalPlayer : RemotePlayer; } }
    public static Player BlackPlayer { get { return LocalPlayer.ControlledColor == Black ? LocalPlayer : RemotePlayer; } }
    public PieceColor ControlledColor { get; private set; }
    public string Name;
    public bool Active;

    private Player()
    {
        Active = true;
        ControlledColor = White;
    }

    public void EndTurn() => Active = false;

    public void BeginTurn() => Active = true;
}
