using HTC.UnityPlugin.Vive;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class righthandcontrol : MonoBehaviour
{
    public GameObject targetPoint;
    private GameObject[] selectedObject;
    int layerMask, layerMask1;
    public Ray ray;

    void Awake()
    {
        layerMask = LayerMask.GetMask("interactable");
        layerMask1 = ~LayerMask.GetMask("interactable");
        targetPoint.GetComponent<Light>().color = new UnityEngine.Color(1f, 1f, 1f, 1f);
        selectedObject = GameObject.FindGameObjectsWithTag("empty");
    }
    void Update()
    {
        RaycastHit hit;
        ray = new Ray(transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            targetPoint.transform.position = hit.point;
            targetPoint.GetComponent<Light>().color = new UnityEngine.Color(1f, 0f, 0f, 1f);

            if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip))
            {
                if (hit.collider.tag == "LIghtSwitch")
                    hit.collider.GetComponent<LightSwitch>().isLightOn = !(hit.collider.GetComponent<LightSwitch>().isLightOn);
                else if (hit.collider.tag == "LightSwitch1")
                    hit.collider.GetComponent<LightSwitch1>().isLightOn = !(hit.collider.GetComponent<LightSwitch1>().isLightOn);
                else if (hit.collider.tag == "door")
                    hit.collider.GetComponentInParent<DoorRotate>().t = !(hit.collider.GetComponentInParent<DoorRotate>().t);
                else if (hit.collider.tag == "door1")
                    hit.collider.GetComponentInParent<Doormove>().t = !(hit.collider.GetComponentInParent<Doormove>().t);
                else if (hit.collider.tag == "door2")
                    hit.collider.GetComponent<DoorRotate>().t = !(hit.collider.GetComponent<DoorRotate>().t);
                else if (hit.collider.tag == "Faucet")
                    hit.collider.GetComponent<Faucet>().t = !(hit.collider.GetComponent<Faucet>().t);
                else if (hit.collider.tag == "drag")
                {
                    selectedObject[0].GetComponent<NewBehaviourScript>().tr = !(selectedObject[0].GetComponent<NewBehaviourScript>().tr);
                    selectedObject[0].GetComponent<NewBehaviourScript>().hitr = hit;
                }

            }
            else if(ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger))
            {
                if (selectedObject[0].GetComponent<NewBehaviourScript>().tr)
                {
                    selectedObject[0].GetComponent<NewBehaviourScript>().rotate = true;
                }
            }
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask1))
        {
            targetPoint.transform.position = hit.point;
            targetPoint.GetComponent<Light>().color = new UnityEngine.Color(1f, 1f, 1f, 1f);
        }

        if (selectedObject[0].GetComponent<NewBehaviourScript>().tr)
        {
            selectedObject[0].GetComponent<NewBehaviourScript>().hitr = hit;
        }
    }
}
