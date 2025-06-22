using System.Collections;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightObject1;
    public GameObject lightObject2;
    public GameObject switchOnObject;
    public GameObject switchOffObject;
    public bool isLightOn = false;

    void Start()
    {
        // Initialize the switch state
        lightObject1.SetActive(isLightOn);
        lightObject2.SetActive(isLightOn);
        switchOnObject.SetActive(false);
        switchOffObject.SetActive(true);
    }

    // This method is triggered when the switch is clicked or touched
    void Update()
    {
        if (isLightOn)
        {
            lightObject1.SetActive(isLightOn);
            lightObject2.SetActive(isLightOn);
            switchOnObject.SetActive(true);
            switchOnObject.GetComponent<LightSwitch>().isLightOn = isLightOn;
            switchOffObject.SetActive(false);
        }
        else
        {
            lightObject1.SetActive(isLightOn);
            lightObject2.SetActive(isLightOn);
            switchOnObject.SetActive(false);
            switchOffObject.GetComponent<LightSwitch>().isLightOn = isLightOn;
            switchOffObject.SetActive(true);
        }
    }
}