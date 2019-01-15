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

    [SerializeField]
    private float m_StepInterval;

    private float m_StepCycle;

    private float m_NextStep;

    [SerializeField]
    private AudioClip[] m_FootstepSounds;
    [SerializeField]
    private AudioClip[] m_FootstepEcho;
    [SerializeField]
    private AudioSource m_AudioSource;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();

        motor.Move(Vector3.zero);
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2;
        m_AudioSource.volume = 0.8f;
    }

    private void Update()
    {
        LookAxis = touchField.TouchDist;
        if (GameManager.instance.interact || Inventory.instance.isInven || Dialogue.instance.isDialogue)
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

        if (_velocity.sqrMagnitude > 0 && (joystick.Horizontal != 0 || joystick.Vertical != 0))
        {
            m_StepCycle += (_velocity.magnitude + (speed * (motor.IsWalking(_velocity) ? 1f : 0f))) * Time.deltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();

       // Debug.Log(m_StepCycle + " & " + m_NextStep );
        //AudioManager.instance.Play("Footsteps_Normal");
    }

    private void PlayFootStepAudio()
    {
        string scene = GameManager.instance.GetScene();
        int n;
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        if(scene.Equals("Prologue") || scene.Equals("Epilogue"))
        {
            n = Random.Range(1, m_FootstepEcho.Length);
            m_AudioSource.clip = m_FootstepEcho[n];
        }
        else
        {
            n = Random.Range(1, m_FootstepSounds.Length);
            m_AudioSource.clip = m_FootstepSounds[n];
        }
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}
