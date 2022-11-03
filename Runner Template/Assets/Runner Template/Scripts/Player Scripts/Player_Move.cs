using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Vector2 IN_touch_POS, MOV_touch_POS;
    Vector3 deah;

    [SerializeField] Rigidbody rgb;

    public float max_speed, minX, maxX, _moveMODIFIER, forward_speed;
    float _delta_x;

    [SerializeField] Player_Collision_Handler p_col;

    public Vector3 moveVEC;

    void Start()
    {
        moveVEC = new Vector3(0, 0, 1);
    }

    //void FixedUpdate()
    //{

    //}

    void Update()
    {
        LimitVelocity(max_speed);
        Limit_X_Axis();
        MoveForward();
        LR_movement();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IN_touch_POS = touch.deltaPosition;
                    break;

                case TouchPhase.Moved:
                    MOV_touch_POS = touch.deltaPosition;
                    _delta_x = MOV_touch_POS.x - IN_touch_POS.x;
                    break;

                case TouchPhase.Stationary:
                    _delta_x = 0;
                    deah = new Vector3(0, 0, rgb.velocity.z);
                    rgb.velocity = deah;
                    break;

                default:
                    break;
            }
        }
        else // Doesn't touch the screen
        {
            _delta_x = 0;
            deah = new Vector3(0, 0, rgb.velocity.z);
            rgb.velocity = deah;
        }
    }

    void MoveForward()
    {
        Vector3 myForward = transform.TransformDirection(Vector3.forward);
        transform.Translate(myForward * forward_speed * Time.deltaTime);
    }

    void LimitVelocity(float xxx)
    {
        rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, xxx);
    }

    void Limit_X_Axis()
    {
        Vector3 clampedPOSX = transform.position;

        clampedPOSX.x = Mathf.Clamp(clampedPOSX.x, -2.5f, 2.5f);
        transform.position = clampedPOSX;
    }

    void LR_movement()
    {
        Vector3 pospos = new Vector3(_delta_x, 0, 0) * _moveMODIFIER;

        pospos = Vector3.ClampMagnitude(pospos, 7500);

        Debug.Log((pospos * _moveMODIFIER).magnitude);

        rgb.AddForce(pospos * Time.deltaTime);
    }
}
