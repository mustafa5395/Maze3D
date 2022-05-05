using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX =100;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    public float currentY;
  

    private void Start()
    {
        camTransform = transform;

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            distance = 4;
            currentY = 25;
        }

        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            distance = 3;
            currentY = 20;
        }

      

    }

    private void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
