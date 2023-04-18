using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D5CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float giroSpeed;
    [SerializeField] private CinemachineVirtualCamera Cam1, Cam2;


    private void Start()
    {
        Cam1.enabled = Cam1.enabled;
        Cam2.enabled = false;
    }
    void Update()
    {
        Move();
        ChangeCamera();
    }


    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        transform.Rotate(Vector3.up, horizontal * giroSpeed * Time.deltaTime);
    }

    public void ChangeCamera() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Cam1.enabled = !Cam1.enabled;
            Cam2.enabled = !Cam2.enabled;
        }
    }
}