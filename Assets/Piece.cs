using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public static Piece SelectedPiece;
    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
        SelectedPiece = this;
        Debug.Log(SelectedPiece.name);
    }
}
