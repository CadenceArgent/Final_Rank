using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PieceName;

public class RadialMenu : MonoBehaviour
{
    private Vector2 Mouseposition;
    private Vector2 fromVector2M = new Vector2(0.5f, 0.5f);
    private Vector2 centercircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M;
    private int oldMenuItem;

    public float angle;
    public int menuItems;
    public int curMenuItem;
    public float fillPercent;
    public List<MenuButton> buttons = new List<MenuButton>();
    
    private void Start()
    {
        menuItems = buttons.Count;
        fillPercent = (360 / buttons.Count) / 360;
        foreach (MenuButton button in buttons)
        {
            button.sceneimage.color = button.NormalColor;
        }
        curMenuItem = 0;
        oldMenuItem = 0;
    }
    
    private void Update()
    {
        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        toVector2M = new Vector2(Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);
        angle = (Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) - Mathf.Atan2(toVector2M.y - centercircle.y, toVector2M.x - centercircle.x)) * Mathf.Rad2Deg + 90f;
        if (angle < 0)
        {
            angle += 360;
        }
        else if (angle >= 360)
        {
            angle -= 360;
        }
        curMenuItem = (int)(angle / (360 / menuItems));
        if (curMenuItem != oldMenuItem)
        {
            buttons[oldMenuItem].sceneimage.color = buttons[oldMenuItem].NormalColor;
            oldMenuItem = curMenuItem;
            buttons[curMenuItem].sceneimage.color = buttons[curMenuItem].HighlightedColor;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Promote();
        }
    }

    public void Promote()
    {
        switch (buttons[curMenuItem].name)
        {
            case string queen when queen == Queen.ToString():
                Board.Current.Promote(Queen);
                break;
            case string rook when rook == Rook.ToString():
                Board.Current.Promote(Rook);
                break;
            case string bishop when bishop == Bishop.ToString():
                Board.Current.Promote(Bishop);
                break;
            case string knight when knight == Knight.ToString():
                Board.Current.Promote(Knight);
                break;
            default:
                Debug.LogWarning($"Couldn't promote you to {buttons[curMenuItem].name}");
                    break;
        }
        buttons[curMenuItem].sceneimage.color = buttons[curMenuItem].PressedColor;
    }
}

[Serializable]
public class MenuButton
{
    public string name;
    public Image sceneimage;
    public Color NormalColor = Color.white;
    public Color HighlightedColor = Color.grey;
    public Color PressedColor = Color.cyan;
}