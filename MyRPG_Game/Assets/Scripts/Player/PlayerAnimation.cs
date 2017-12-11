using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerMove move;

    void Start()
    {
        move = this.GetComponent<PlayerMove>();
    }

    void LateUpdate()
    {
        if (move.state == PlayerState.Moving)
        {
            PlayAnim("Sword-Walk");
        }
        else if (move.state == PlayerState.Idle)
        {
            PlayAnim("Sword-Idle");
        }
    }

    void PlayAnim(string animName)
    {
        this.GetComponent<Animation>().CrossFade(animName);
    }
}
