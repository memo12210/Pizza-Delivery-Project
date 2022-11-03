using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public Transform TARGET;

    public float smooth_speed = 0.1f;
    public Vector3 offset;

    void Start()
    {
       
    }

    void LateUpdate()
    {
        Vector3 desiredPOSS = new Vector3(0, TARGET.position.y - offset.y, TARGET.position.z - offset.z);



        Vector3 desiresPOS = TARGET.position - offset;
        //Vector3 clamp_x;
        transform.position = desiredPOSS;
        //clamp_x = transform.position;

        //clamp_x.x = Mathf.Clamp(clamp_x.x, 0, 0);
        //transform.position = clamp_x;
    }
}
