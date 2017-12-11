using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 offsetPosition;
    public float distance = 0;
    public float scrollSpeed = 1;
    private bool isRotate = false;
    public int rotateSpeed = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    void Update()
    {
        transform.position = offsetPosition + player.position;
        //处理视野的旋转
        RotateView();
        //视野拉近和拉远效果
        ScrollView();
       
    }

    void ScrollView()
    {
        
        distance = offsetPosition.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        //distance = Mathf.Clamp(distance, 2, 18);
        offsetPosition = offsetPosition.normalized * distance;

    }

    void RotateView()
    {
//         Input.GetAxis("Mouse X");//得到鼠标水平方向的滑动
//         Input.GetAxis("Mouse Y");//得到鼠标垂直方向的滑动

        if (Input.GetMouseButtonDown(1))
        {
            isRotate= true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }
        if (isRotate)
        {
            transform.RotateAround(player.position, Vector3.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            float x = transform.eulerAngles.x;
            if (x<10||x>80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }

        }
        offsetPosition = transform.position - player.position;
    }
}
