using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private GameObject resultManager;

    // Update is called once per frame
    void Update()
    {
        SetHighestPosition("fruit01");
        SetHighestPosition("fruit02");
        SetHighestPosition("fruit03");
        SetHighestPosition("fruit04");
        SetHighestPosition("fruit05");
        SetHighestPosition("fruit06");
        SetHighestPosition("fruit07");
        SetHighestPosition("fruit08");
    }

    void SetHighestPosition(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        float highest_p = -500;
        var instanceObject = GameObject.Find("InstancePosition");
        float instance_p = instanceObject.transform.localPosition.y;
        //Debug.Log("現在のInstancePosition位置：" + instance_p);

        foreach (GameObject gameObj in gameObjects)
        {
            if (gameObj.GetComponent<BaseFruit>().isRelease)
            {
                if (highest_p < gameObj.transform.localPosition.y) highest_p = gameObj.transform.localPosition.y;
            }

            //Debug.Log("オブジェクト名：" + gameObj.name + ", 高さ：" + gameObj.transform.localPosition.y + ", 現在の最高高さ：" + highest_p);
        }

        //Set InstancePosition
        if (highest_p > instance_p - 100)
        {
            Debug.Log("ゲーム終了！！");
            resultManager.SetActive(true);
        }
    }
}
