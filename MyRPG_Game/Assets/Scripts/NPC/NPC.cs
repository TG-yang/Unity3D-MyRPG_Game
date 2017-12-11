
using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    void OnMouseEnter()
    {
        CursorManager._instance.SetNpcTalk();
    }

    void OnMouseExit()
    {
        CursorManager._instance.SetNormal();
    }
}
