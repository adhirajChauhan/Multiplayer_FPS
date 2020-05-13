using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _lookSensitivity = 3f;

    private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Movement
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * _speed;

        motor.Move(_velocity);

        //Rotation
        float _yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * _lookSensitivity;

        motor.Rotate(_rotation);


        float _xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * _lookSensitivity;

        motor.RotateCamera(_cameraRotation);
    }
}
