using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PieceColor;
using static Player;
using static Board;

public class Piece : MonoBehaviour
{
    #region Properties
    public static Piece SelectedPiece;
    public Vector2 Position
    {
        get { return GetComponentInParent<Tile>().Position; }
        set { transform.SetParent(Current.Tiles.Single(element => element.Position == value).transform); }
    }
    public PieceColor Color;
    public IMoveStrategy MovementType;
    #endregion

    #region Fields
    private List<Vector2> AvailableTiles
    {
        get { return null; }
    }
    #endregion

    #region Unity Methods
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Color != None && Color == LocalPlayer.ControlledColor)
        {
            SelectedPiece = SelectedPiece == this ? null : this;
            Debug.Log(SelectedPiece?.name);
        }
    }

    public List<Vector2> GetReachableTiles()
    {
        return MovementType.GetAvailableTiles(GetComponentInParent<Tile>().Position);
    }
    #endregion

    #region Methods
    public bool CanMove(Vector2 Destination)
    {
        return AvailableTiles.Contains(Destination);
    }
    #endregion
}
