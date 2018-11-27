using UnityEngine;
using System.Collections.Generic;

public interface IMoveStrategy
{
    List<Vector2> GetAvailableTiles(Vector2 Origin);
    void Move(Tile Destination);
}