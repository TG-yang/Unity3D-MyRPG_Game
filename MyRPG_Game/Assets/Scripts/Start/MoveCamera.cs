using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

    public float speed = 10;
    private float endZ = -20;

    void Update()
    {
        if (transform.position.z < endZ)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
       
    }
}
