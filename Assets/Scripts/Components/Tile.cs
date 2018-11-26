﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Properties
    public Vector2 Position;
    public bool IsSlow;
    public bool IsEmpty { get { return GetComponentInChildren<Piece>() == null; } }
    public Piece ContainedPiece { get { return GetComponentInChildren<Piece>(); } }
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(this.Position);
        }
    }
    #endregion
}
