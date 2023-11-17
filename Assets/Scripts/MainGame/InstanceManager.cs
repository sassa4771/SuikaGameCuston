using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SasaUtility;

public class InstanceManager : Singleton<InstanceManager>
{
    public List<GameObject> Fruits = new List<GameObject>();

    public struct instancePram
    {
        public GameObject InstanceObject;
        public Vector2 RevealPosition;
        public GameObject ParentObject;
        public float Scale;
        public string ObjectName;
    }

    //Instance Object in 2D
    public GameObject Instance_Object(instancePram parm)
    {
        GameObject instance_object;
        if (parm.ParentObject != null)instance_object = Instantiate(parm.InstanceObject, new Vector3(parm.RevealPosition.x, parm.RevealPosition.y, -2), Quaternion.identity, parm.ParentObject.transform);
        else instance_object = Instantiate(parm.InstanceObject, new Vector3(parm.RevealPosition.x, parm.RevealPosition.y, -2), Quaternion.identity);

        //Hierarchy上の名前とScaleを決める
        instance_object.name = parm.InstanceObject.name;
        instance_object.transform.localScale = new Vector3(parm.Scale, parm.Scale, parm.Scale);

        return instance_object;

    }

    public GameObject LoadResourceRandomSelect()
    {
        if (Fruits.Count > 0)
        {
            return Fruits[Random.Range(0, Fruits.Count)];
        }
        else
        {
            // エラー処理やデフォルトの戻り値を指定するなど、適切な対応を行う
            return null; // 例: null を返す
        }
    }
}
