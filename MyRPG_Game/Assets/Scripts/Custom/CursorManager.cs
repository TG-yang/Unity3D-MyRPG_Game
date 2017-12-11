using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
    public static CursorManager _instance;

    public Texture2D cursor_normal;
    public Texture2D cursor_npcTalk;
    public Texture2D cursor_pick;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;

    private Vector2 hotspot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;

    void Start()
    {
        _instance = this;
    }


    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal, hotspot, mode);
    }

    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npcTalk, hotspot, mode);
    }
    
}
