using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    #region Porperties
    public static Board Current { get { return GameObject.Find("CurrentBoard").GetComponent<Board>(); } }
    public List<Tile> Tiles { get { return Current.GetComponentsInChildren<Tile>().ToList(); } }
    public GameObject PrefabWhite;
    public GameObject PrefabBlack;
    public GameObject PrefabSlowWhite;
    public GameObject PrefabSlowBlack;
    #endregion

    #region Unity Methods
    private void Start()
    {

    }

    private void Update()
    {

    }
    #endregion
}