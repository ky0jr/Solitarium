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

    public Vector2 LookAxis;

    public FixedTouchField touchField;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        LookAxis = touchField.TouchDist;
        if (GameManager.instance.interact || Inventory.instance.isInven)
        {
            motor.Move(Vector3.zero);
            return;
        }

        //Calculate movement velocity as a 3D vector
        float _xMov = joystick.Horizontal;
        float _zMov = joystick.Vertical;


        Vector3 _movVertical = transform.forward * _zMov;
        Vector3 _movHorizontal = transform.right * _xMov;

        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector
        float _yRot = LookAxis.x;

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector
        float _xRot = LookAxis.y;
        float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotationX);
            
    }


}
