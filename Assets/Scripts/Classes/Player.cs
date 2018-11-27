using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PieceColor;

public class Player
{
    public static Player LocalPlayer = new Player();
    public static Player RemotePlayer = new Player();
    public PieceColor ControlledColor { get; private set; }
    public string Name;
    public bool Active;

    private Player()
    {
        Active = true;
        ControlledColor = White;
    }

    public void EndTurn()
    {
        Active = false;
    }
}
