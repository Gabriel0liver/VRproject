using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class RecenterOrigin : MonoBehaviour
{

    public Camera head;
    public GameObject player;
    public Transform target;

    void Start()
    {
        Recenter();
    }

    public void Recenter()
    {
        var rotationAngleY = head.transform.rotation.eulerAngles.y - target.eulerAngles.y;
        player.transform.Rotate(0, -rotationAngleY, 0);

        var distanceDiff = target.position - head.transform.position;
        player.transform.position += distanceDiff;
    }
}
