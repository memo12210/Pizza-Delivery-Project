using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade_Script : MonoBehaviour
{
    public float rotate_speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotate_speed * Time.deltaTime));
    }
}
