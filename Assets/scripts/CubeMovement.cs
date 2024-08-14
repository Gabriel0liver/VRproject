using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private float speed = 0f;
    public Vector3 direction = Vector3.forward;

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        // Calculate the movement amount
        Vector3 movement = direction.normalized * -speed * Time.deltaTime;

        // Move the object
        transform.position += movement;
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }

}
