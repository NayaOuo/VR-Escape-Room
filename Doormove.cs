using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Doormove : MonoBehaviour
{
    public float open;
    private Vector3 openposition;
    private Vector3 closeposition;
    private Vector3 currentposition;
    private bool isOpening = false;
    private bool isClosing = false;
    public bool t = false;
    public GameObject door;
    public AudioSource audioData1;
    public AudioSource audioData2;

    void Start()
    {
        openposition = new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, open);
        closeposition = door.transform.localPosition;
        currentposition = door.transform.localPosition;

    }
    void Update()
    {

        if (t)
        {
            if (!isOpening && !isClosing)
            {
                if (currentposition == closeposition)
                {
                    isOpening = true;
                    audioData1.Play(0);
                }
                else if (currentposition == openposition)
                {
                    isClosing = true;
                    audioData2.Play(0);
                }
            }
            t = !t;
        }
        
        if(isOpening)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, openposition, Time.deltaTime);

            if (System.Math.Abs(door.transform.localPosition.z - openposition.z) <= 0.001)
            {
                isOpening = false;
                door.transform.localPosition = openposition;
                currentposition = openposition;
            }
        }

        if (isClosing)
        {
            door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, closeposition, Time.deltaTime);

            if (System.Math.Abs(door.transform.localPosition.z - closeposition.z) <= 0.001)
            {
                isClosing = false;
                door.transform.localPosition = closeposition;
                currentposition = closeposition;
            }
        }
    }
}
