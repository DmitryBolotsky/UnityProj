using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceJoy : MonoBehaviour
{
    private ProgrammManager ProgrammManagerScript;

    protected Joystick joystick;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();


    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        //rigidbody.velocity = new Vector3(joystick.Horizontal * 100f, rigidbody.velocity.y, joystick.Vertical * 100f);
        rigidbody.transform.position = transform.position + new Vector3(joystick.Horizontal + 10, joystick.Vertical + 10, rigidbody.velocity.z);
    }
}
