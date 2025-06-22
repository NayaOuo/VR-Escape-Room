using System.Collections;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class LightSwitch1 : MonoBehaviour
{
    public GameObject lightObject;
    public GameObject switchOnObject;
    public GameObject switchOffObject;
    public bool isLightOn = false;

    void Start()
    {
        lightObject.SetActive(isLightOn);
        switchOnObject.SetActive(false);
        switchOffObject.SetActive(true);
    }
    void Update()
    {
        if (isLightOn)
        {
            lightObject.SetActive(isLightOn);
            switchOnObject.SetActive(true);
            switchOnObject.GetComponent<LightSwitch1>().isLightOn = isLightOn;
            switchOffObject.SetActive(false);
        }
        else
        {
            lightObject.SetActive(isLightOn);
            switchOnObject.SetActive(false);
            switchOffObject.GetComponent<LightSwitch1>().isLightOn = isLightOn;
            switchOffObject.SetActive(true);
        }
    }
}