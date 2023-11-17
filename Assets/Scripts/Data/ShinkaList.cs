using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinkaList : MonoBehaviour
{
    [SerializeField] List<GameObject> RevealPosition = new List<GameObject>();
    [SerializeField] List<GameObject> FruitList = new List<GameObject>();

    void Start()
    {
        int i = 0;
        foreach(var fruit in FruitList)
        {
            var param = new InstanceManager.instancePram();
            param.InstanceObject = fruit;
            param.RevealPosition = RevealPosition[i].transform.position;
            param.ParentObject = RevealPosition[i];
            param.Scale = 1;
            param.ObjectName = "Object";

            var newObject = InstanceManager.Instance.Instance_Object(param);

            // RectTransform を取得
            RectTransform rectTransform = newObject.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                // stretch に設定
                rectTransform.anchorMin = new Vector2(0f, 0f);
                rectTransform.anchorMax = new Vector2(1f, 1f);
                rectTransform.pivot = new Vector2(0.5f, 0.5f);

                // Left、Top、Right、Bottom を 0 に設定
                rectTransform.offsetMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;
            }
            else
            {
                Debug.LogError("RectTransformが見つかりませんでした。");
            }

            i++;
        }
    }
}
