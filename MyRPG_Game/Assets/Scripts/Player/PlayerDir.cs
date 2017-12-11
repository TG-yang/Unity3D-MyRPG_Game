using UnityEngine;
using System.Collections;

public class PlayerDir : MonoBehaviour
{

    public GameObject effect_click_prefab;
    private bool isMouseDown = false;
    public Vector3 targetPosition = Vector3.zero;

    private PlayerMove playerMove;
    

    
    void Start()
    {
        targetPosition = this.transform.position;
        playerMove = this.GetComponent<PlayerMove>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UICamera.hoveredObject==null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider&&hitInfo.collider.tag ==Tags.ground)
            {
                ShowClickEffect(hitInfo.point);
                isMouseDown = true;
                LookAtTarget(hitInfo.point);
            }
        }
        



        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }


        if (isMouseDown)
        {
            //得到要移动的位置
            //让主角朝向位置

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);

            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
              LookAtTarget(hitInfo.point);
            }


        }
        else
        {
            if (playerMove.isMoving)
            {
                LookAtTarget(targetPosition);
            }
        }
    }

    

    void ShowClickEffect(Vector3 hitPoint)
    {
        GameObject.Instantiate(effect_click_prefab, hitPoint, Quaternion.identity);
    }

    void LookAtTarget(Vector3 hitPoint)
    {
        targetPosition = hitPoint;
        this.transform.LookAt(targetPosition);
    }
}
