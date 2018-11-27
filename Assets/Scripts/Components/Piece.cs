using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PieceColor;
using static Player;

public class Piece : MonoBehaviour
{
    #region Properties
    public static Piece SelectedPiece
    {
        get { return _selectedPiece; }
        set
        {
            _selectedPiece = value;
            Highlighter.KillAll();
            foreach (Vector2 AvailableTile in value?.GetReachableTiles() ?? new List<Vector2>())
            {
                Board.Current.GetTileByPos(AvailableTile).Highlight();
            }
        }
    }
    public Vector2 Position
    {
        get { return GetComponentInParent<Tile>().Position; }
        set { transform.SetParent(Board.Current.Tiles.Single(element => element.Position == value).transform); }
    }
    public Tile ContainingTile
    {
        get { return transform.parent.GetComponent<Tile>(); }
        set
        {
            transform.SetParent(value.transform);
            transform.localPosition = new Vector3(-0.5f, 0.5f, 0);
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public PieceColor Color
    {
        get { return _color; }
        set
        {
            _color = value;
            GetComponent<MeshRenderer>().materials.ToList().ForEach(material => material.color = value == White ? UnityEngine.Color.white : UnityEngine.Color.black);
        }
    }
    public IMoveStrategy MovementType { private get; set; }
    #endregion

    #region Fields
    private PieceColor _color;
    private static Piece _selectedPiece;
    #endregion

    #region Unity Methods
    private void OnMouseDown()
    {
        if (Color != None && Color == LocalPlayer.ControlledColor && LocalPlayer.Active)
        {
            SelectedPiece = SelectedPiece == this ? null : this;
        }
        else if (SelectedPiece.CanMove(ContainingTile.Position))
        {
            SelectedPiece.Move(ContainingTile);
        }
    }
    #endregion

    #region Methods
    private List<Vector2> GetReachableTiles() => MovementType.GetAvailableTiles(GetComponentInParent<Tile>().Position);

    public bool CanMove(Vector2 Destination) => GetReachableTiles().Contains(Destination);

    public void Move(Tile Destination)
    {
        MovementType.Move(Destination);
    }
    #endregion
}
