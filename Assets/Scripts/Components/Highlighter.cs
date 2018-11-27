using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    private void OnMouseDown()
    {
        Piece.SelectedPiece.Move(transform.parent.GetComponent<Tile>());
    }

    public static void KillAll()
    {
        foreach (GameObject element in GameObject.FindGameObjectsWithTag(Tags.highlight.ToString()))
        {
            if (element.name != "highlighter")
            {
                Destroy(element);
            }
        }
    }
}
