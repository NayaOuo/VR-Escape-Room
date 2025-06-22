using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorRotate : MonoBehaviour
{
    public float OpenAngle = 90f;
    private Quaternion closeAngle;
    private Quaternion currentAngle;
    private Quaternion openAngle;
    private bool isOpening = false;
    private bool isClosing = false;
    public bool t = false;
    public GameObject door;
    public AudioSource audioData1;
    public AudioSource audioData2;

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
                {
                    isOpening = true;
                    audioData1.Play(0);
                }
                else if (currentAngle == openAngle)
                {
                    isClosing = true;
                    audioData2.Play(0);
                }
            }
            t = !t;
        }

        if (isOpening)
        {
            door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openAngle, Time.deltaTime);

            if (System.Math.Abs(door.transform.eulerAngles.y - OpenAngle) <= 1)
            {
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
                isClosing = false;
                door.transform.rotation = closeAngle;
                currentAngle = closeAngle;
            }
        }
    }
}
