using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Properties
    public Vector2 Position;
    public bool IsSlow;
    public Piece ContainedPiece { get { return GetComponentInChildren<Piece>(); } }
    #endregion
}
