using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public static Player LocalPlayer = new Player();
    public static Player RemotePlayer = new Player();
    public PieceColor ControlledColor;

    private Player()
    {
        ControlledColor = PieceColor.White;
    }
}
