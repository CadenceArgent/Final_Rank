using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PieceColor;
using static Player;

public class Piece : MonoBehaviour
{
    #region Properties
    public static Piece SelectedPiece;
    public Vector2 Position
    {
        get { return GetComponentInParent<Tile>().Position; }
        set { transform.SetParent(Board.Current.Tiles.Single(element => element.Position == value).transform); }
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
    public IMoveStrategy MovementType;
    #endregion

    #region Fields
    private PieceColor _color;
    #endregion

    #region Unity Methods
    private void OnMouseDown()
    {
        if (Color != None && Color == LocalPlayer.ControlledColor)
        {
            SelectedPiece = SelectedPiece == this ? null : this;
            foreach (GameObject element in GameObject.FindGameObjectsWithTag(Tags.highlight.ToString()))
            {
                if (element.name != "highlighter")
                {
                    Destroy(element);
                }
            }
            foreach (Vector2 AvailableTile in SelectedPiece?.GetReachableTiles() ?? new List<Vector2>())
            {
                Board.Current.GetTileByPos(AvailableTile).Highlight();
            }
        }
    }
    #endregion

    #region Methods
    public List<Vector2> GetReachableTiles() => MovementType.GetAvailableTiles(GetComponentInParent<Tile>().Position);
    #endregion
}
