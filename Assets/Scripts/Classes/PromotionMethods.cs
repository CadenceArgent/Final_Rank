using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PieceName;

public class PromotionMethods : MonoBehaviour
{
    public void PromoteQueen()
    {
        Board.Current.Promote(Queen);
    }

    public void PromoteRook()
    {
        Board.Current.Promote(Rook);
    }

    public void PromoteBishop()
    {
        Board.Current.Promote(Bishop);
    }

    public void PromoteKnight()
    {
        Board.Current.Promote(Knight);
    }
}
