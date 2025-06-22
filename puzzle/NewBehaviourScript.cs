using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject selectedObjectl, selectedObjectr;
    public GameObject subtitleBox; //to be continued
    public GameObject picture;
    public bool tr = false; // 是否抓取狀態
    public bool tl = false; // 是否抓取狀態
    public RaycastHit hitr, hitl; // 來自控制器的射線檢測結果
    public bool rotate = false;
    private Vector3 offset; // 抓取時的相對位移
    GameObject[] dragObj;
    GameObject[] dropObj;
    public GameObject myparticle;
    public GameObject box;
    public AudioSource audio2;
    public AudioSource audio1;


    void Start()
    {
        dragObj = GameObject.FindGameObjectsWithTag("drag");
        dropObj = GameObject.FindGameObjectsWithTag("drop");
        box = GameObject.Find("Chest_Silver");
        box.SetActive(false);
        subtitleBox.SetActive(false);
        dragObj = dragObj.OrderBy(obj => obj.name).ToArray();
        dropObj = dropObj.OrderBy(obj => obj.name).ToArray();
        picture.SetActive(false);
    }

    void Update()
    {
        if (tr)
        {
            // 抓取邏輯
            if (selectedObjectr == null && hitr.collider != null && hitr.collider.CompareTag("drag"))
            {
                selectedObjectr = hitr.collider.gameObject;
                offset = selectedObjectr.transform.position - hitr.point; // 計算抓取時的位移
            }
            else if (selectedObjectr != null)
            {
                // 更新抓取物體的位置
                selectedObjectr.transform.position = hitr.point + offset;
                if (rotate)
                {
                    selectedObjectr.transform.rotation = Quaternion.Euler(new Vector3(selectedObjectr.transform.rotation.eulerAngles.x, selectedObjectr.transform.rotation.eulerAngles.y + 90f, selectedObjectr.transform.rotation.eulerAngles.z));
                    rotate = false;
                }
            }
        }
        else if (selectedObjectr != null)
        {
            // 放下邏輯
            Vector3 position = hitr.point;
            Vector3 tmpdrop = Vector3.zero;
            float minDistance = 10.0f;

            foreach (var item in dropObj)
            {
                if (Vector3.Distance(item.transform.position, position) <= minDistance)
                {
                    minDistance = Vector3.Distance(item.transform.position, position);
                    tmpdrop = item.transform.position;
                }
            }

            if (minDistance < 0.5f)
            {
                selectedObjectr.transform.position = tmpdrop + new Vector3(0, 0.05f, 0);
                audio1.Play(0);
                check();
            }
            else
            {
                selectedObjectr.transform.position = position;
            }

            selectedObjectr = null;
        }
        
        if (tl)
        {
            if (selectedObjectl == null && hitl.collider != null && hitl.collider.CompareTag("drag"))
            {
                selectedObjectl = hitl.collider.gameObject;
                offset = selectedObjectl.transform.position - hitl.point; // 計算抓取時的位移
            }
            else if (selectedObjectl != null)
            {
                // 更新抓取物體的位置
                selectedObjectl.transform.position = hitl.point + offset;
                if (rotate)
                {
                    selectedObjectl.transform.rotation = Quaternion.Euler(new Vector3(selectedObjectl.transform.rotation.eulerAngles.x, selectedObjectl.transform.rotation.eulerAngles.y + 90f, selectedObjectl.transform.rotation.eulerAngles.z));
                    rotate = false;
                }
            }
        }
        else if (selectedObjectl != null)
        {
            // 放下邏輯
            Vector3 position = hitl.point;
            Vector3 tmpdrop = Vector3.zero;
            float minDistance = 10.0f;

            foreach (var item in dropObj)
            {
                if (Vector3.Distance(item.transform.position, position) <= minDistance)
                {
                    minDistance = Vector3.Distance(item.transform.position, position);
                    tmpdrop = item.transform.position;
                }
            }

            if (minDistance < 0.5f)
            {
                selectedObjectl.transform.position = tmpdrop + new Vector3(0, 0.05f, 0);
                audio1.Play(0);
                check();
            }
            else
            {
                selectedObjectl.transform.position = position;
            }

            selectedObjectl = null;
        }
    }

    public void check()
    {
        bool isDone = true;
        int childCount = dropObj.Length;

        for (int i = 0; i < childCount; i++)
        {
            Vector3 dropPos = dropObj[i].transform.position;
            Vector3 dragPos = dragObj[i].transform.position;

            if (dragPos != dropPos + new Vector3(0, 0.05f, 0))
            {
                isDone = false;
                break;
            }
        }
        if(isDone)
        {
            GameObject showparticle = Instantiate(myparticle);
            box.SetActive(true);
            picture.SetActive(true);
            audio2.Play(0);
            showparticle.transform.position = GameObject.Find("Chest_Silver").transform.position;
            Invoke("ShowSubtitle", 6f);
            ShowSubtitle(); // 顯示字幕框
            //Debug.Log("FINISH!! Excellent!");
        }
        else
        {
            //Debug.Log("Not finish yet! QQ");
        }
    }
    void ShowSubtitle()
    {
        subtitleBox.SetActive(true); // 顯示字幕框
    }
}