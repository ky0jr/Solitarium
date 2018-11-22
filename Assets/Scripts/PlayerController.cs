using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Joystick joystick;                     

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lookSensitivity = 10f;

    private PlayerMotor motor;

    private Touch initTouch = new Touch();

    private float _xRot = 0f;
    private float _yRot = 0f;

    private float _cameraRotationX = 0f;

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
            //motor.Rotate(Vector3.zero);
            //motor.RotateCamera(_cameraRotationX);
            return;
        }

        //Calculate movement velocity as a 3D vector
        float _xMov = joystick.Horizontal;
        float _zMov = joystick.Vertical;


        Vector3 _movVertical = transform.forward * _zMov;
        Vector3 _movHorizontal = transform.right * _xMov;
        //Debug.Log((_movHorizontal + _movVertical).normalized);
        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

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
        
    }

    //public void CameraControl()
    //{
    //    foreach (Touch touch in Input.touches)
    //    {
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            initTouch = touch;

    //        }
    //        else if (touch.phase == TouchPhase.Moved)
    //        {
    //            _xRot -= touch.deltaPosition.y * Time.deltaTime;
    //            _yRot += touch.deltaPosition.x * Time.deltaTime;
    //            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
    //            motor.Rotate(_rotation);
    //            _cameraRotationX = _xRot * lookSensitivity;
    //            motor.RotateCamera(_cameraRotationX);
    //        }
    //        else if (touch.phase == TouchPhase.Ended)
    //        {
    //            initTouch = new Touch();
    //        }
    //    }
    //}

    public void CameraControl()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _xRot -= touch.deltaPosition.y * Time.deltaTime;
                _yRot += touch.deltaPosition.x * Time.deltaTime;
                Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
                motor.Rotate(_rotation);
                _cameraRotationX = _xRot * lookSensitivity;
                motor.RotateCamera(_cameraRotationX);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
