using UnityEngine;
using System.Collections;


public enum PlayerState
{
    Moving,
    Idle
}
public class PlayerMove : MonoBehaviour
{

    public float speed = 4f;
    private PlayerDir dir;
    public PlayerState state = PlayerState.Idle;
    private CharacterController controller;
    public bool isMoving = false;

    void Start()
    {
        dir = this.GetComponent<PlayerDir>();
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        float distance = Vector3.Distance(dir.targetPosition, transform.position);
        if (distance > 0.5f)
        {
            isMoving = true;
            state = PlayerState.Moving;
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            isMoving = false;
            state = PlayerState.Idle;
        }
    }
}
