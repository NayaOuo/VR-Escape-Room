using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ROTATE : MonoBehaviour
{
    public float OpenAngle = 90f;
    private Quaternion closeAngle;
    private Quaternion currentAngle;
    private Quaternion openAngle;
    private bool isOpening = false;
    private bool isClosing = false;
    public bool t = false;
    public GameObject door;

    private void Start()
    {
        currentAngle = door.transform.rotation;
        closeAngle = door.transform.rotation;
        openAngle = Quaternion.Euler(0f, OpenAngle, 0f);
    }

    void Update()
    {
        if (t)
        {
            if (!isOpening && !isClosing)
            {
                if (currentAngle == closeAngle)
                    isOpening = true;
                else if (currentAngle == openAngle)
                    isClosing = true;
            }
            t = !t;
        }

        if (isOpening)
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openAngle, Time.deltaTime);

            if (System.Math.Abs(door.transform.eulerAngles.y - OpenAngle) <= 1)
            {
                Debug.Log("isOpening is false");
                isOpening = false;
                door.transform.rotation = openAngle;
                currentAngle = openAngle;
            }
        }

        if (isClosing)
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, closeAngle, Time.deltaTime);

            if (System.Math.Abs(door.transform.eulerAngles.y - closeAngle.eulerAngles.y) <= 1)
            {
                Debug.Log("isClosing is false");
                isClosing = false;
                door.transform.rotation = closeAngle;
                currentAngle = closeAngle;
            }
        }
    }
}
