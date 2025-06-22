using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Faucet : MonoBehaviour
{
    private float openAngle = 20f;     // ���}���ؼШ���
    private Vector3 currentAngle;  // �ֿn�����ਤ��
    private Vector3 previousAngle;
    private bool isOpening = false;   // �O�_���b���}
    public bool t = false;
    public GameObject faucet, label;
    public AudioSource audioData1;
    public ParticleSystem water;

    private void Start()
    {
        water.gameObject.SetActive(false);
    }
    void Update()
    {

        if (t)
        {
            currentAngle = faucet.transform.eulerAngles;
            Debug.Log("B : " + currentAngle);

            if (!isOpening)
            {
                audioData1.mute = false;
                audioData1.Play(0);
                water.gameObject.SetActive(true);
                faucet.transform.rotation = Quaternion.Euler(0, 0, openAngle);
                label.transform.rotation = Quaternion.Euler(0, 0, openAngle);
                Debug.Log("Open to : " + faucet.transform.eulerAngles);
                isOpening = true;

            }
            else
            {
                audioData1.mute = true;
                Debug.Log("Prev.Y : " + previousAngle.y);
                water.gameObject.SetActive(false);
                faucet.transform.rotation = Quaternion.Euler(0, 0, previousAngle.y);
                label.transform.rotation = Quaternion.Euler(0, 0, previousAngle.y);
                Debug.Log("Close : " + currentAngle);
                isOpening = false;

            }
            previousAngle = currentAngle;

            t = !t;
        }
    }
}
