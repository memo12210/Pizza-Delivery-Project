using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision_Handler : MonoBehaviour
{

    Quaternion targetROT;
    public float current_Yrot, target_Yrot, _turnMODIFIER, _turnVecLerpValue;
    float speed = 1f;
    public bool R_turner_hit, L_turner_hit, hit_any_turner;

    bool X_axis, Z_axis, NZ_axis;

    public string current_axis;

    Player_Move p_move;

    Rigidbody rgb;
    [SerializeField] Canvas GameOverCanvas; 
    void Start()
    {
        X_axis = true;
        current_axis = "x";
        current_Yrot = 0;
        GameOverCanvas.enabled = false;
        p_move = GetComponent<Player_Move>();
        rgb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (L_turner_hit && current_axis == "x")
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetROT, _turnMODIFIER * Time.deltaTime);
            p_move.moveVEC = Vector3.Lerp(p_move.moveVEC, new Vector3(-1, 0, 0), _turnVecLerpValue);

            if (Quaternion.Angle(transform.rotation, targetROT) < 0.01f)
            {
                current_axis = "nz";
                L_turner_hit = false;
            }
        }

        else if (L_turner_hit && current_axis == "z")
        {
            current_axis = "x";
            L_turner_hit = false;
        }

        else if (R_turner_hit && current_axis == "nz")
        {
            current_axis = "x";
            R_turner_hit = false;
        }

        else if (R_turner_hit && current_axis == "x")
        {
            current_axis = "z";
            R_turner_hit = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Blade")
        {
            GameOverCanvas.enabled = true;
            p_move.forward_speed = 0f;
            p_move._moveMODIFIER = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "L_Turner" && current_axis == "x")
        {
            targetROT = Quaternion.Euler(0, -90, 0);
            L_turner_hit = true;
            hit_any_turner = true;
        }

        else if (other.gameObject.tag == "L_Turner" && current_axis == "z")
        {
            targetROT = Quaternion.Euler(0, 0, 0);
            L_turner_hit = true;
            hit_any_turner = true;
        }

        if (other.gameObject.tag == "R_Turner" && current_axis == "nz")
        {
            targetROT = Quaternion.Euler(0, 0, 0);
            R_turner_hit = true;
            hit_any_turner = true;
        }

        else if (other.gameObject.tag == "R_Turner" && current_axis == "x")
        {
            targetROT = Quaternion.Euler(0, 90, 0);
            R_turner_hit = true;
            hit_any_turner = true;
        }
    }
}
