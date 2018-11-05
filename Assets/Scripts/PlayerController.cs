using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Joystick joystick;

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lookSensitivity = 10f;

    private Vector3 _movHorizontal = Vector3.zero;
    private Vector3 _movVertical = Vector3.zero;

    private PlayerMotor motor;

    private Touch initTouch = new Touch();

    private float _xRot = 0f;
    private float _yRot = 0f;

    public bool swipes;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Debug.Log("Print: " + Time.deltaTime);
        //Debug.Log("Print fix: " + Time.fixedDeltaTime);
        if (GameManager.instance.interact || Inventory.instance.isInven)
        {
            motor.Move(Vector3.zero);
            motor.Rotate(Vector3.zero);
            motor.RotateCamera(0f);
            return;
        }
            
        if(joystick.Horizontal >= 0.2f)
        {
            _movHorizontal = new Vector3(speed,0f,0f);
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            _movHorizontal = new Vector3(-speed, 0f, 0f);
        }
        else
        {
            _movHorizontal = Vector3.zero;
        }

        if (joystick.Vertical >= 0.2f)
        {
            _movVertical = new Vector3(0f, 0f, speed);
        }
        else if (joystick.Vertical <= -0.2f)
        {
            _movVertical = new Vector3(0f, 0f, -speed);
        }
        else
        {
            _movVertical = Vector3.zero;
        }
        //Calculate movement velocity as a 3D vector
        //float _xMov = Input.GetAxisRaw("Horizontal");
        //float _zMov = Input.GetAxisRaw("Vertical");


        //Vector3 _movVertical = transform.forward * _zMov;

        //Final movement vector
        //Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //joystick
        Vector3 moveVector = (_movHorizontal + _movVertical).normalized * speed;
      
        //Apply movement
        motor.Move(moveVector);

        //Calculate rotation as a 3D vector
        //float _yRot = Input.GetAxisRaw("Mouse X");

        //Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        //motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector
        //float _xRot = Input.GetAxisRaw("Mouse Y");

        //float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        //motor.RotateCamera(_cameraRotationX);

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (swipes)
                {
                    _xRot -= touch.deltaPosition.y * Time.deltaTime;
                    _yRot += touch.deltaPosition.x * Time.deltaTime;
                    Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
                    motor.Rotate(_rotation);
                    float _cameraRotationX = _xRot * lookSensitivity;
                    motor.RotateCamera(_cameraRotationX);
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }

    }

    public void SwipeOn()
    {
        swipes = true;
    }

    public void SwipeOff()
    {
        swipes = false;
    }

}
