using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SasaUtility;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InstanceManager im;
    private GameObject NextObject;
    private GameObject PreviousNextObject;

    void Start()
    {
        NextObject = InstanceManager.Instance.LoadResourceRandomSelect();
        MakeNextFruit();
        DataScripts.Score = 0;
    }

    //次に表示されるオブジェクトをネクストに表示する
    public void SetNextFruit()
    {
        NextObject = InstanceManager.Instance.LoadResourceRandomSelect();

        var param = new InstanceManager.instancePram();
        param.InstanceObject = NextObject;
        param.RevealPosition = GameObject.Find("NextInstancePosition").transform.position;
        param.ParentObject = GameObject.Find("NextInstancePosition");
        param.Scale = 1;
        param.ObjectName = "NextObject";

        if (PreviousNextObject != null) Destroy(PreviousNextObject);
        PreviousNextObject = im.Instance_Object(param);
        Destroy(PreviousNextObject.GetComponent<ControllManager>());
    }

    //操作できる次のオブジェクトを表示する
    public void MakeNextFruit()
    {
        var param = new InstanceManager.instancePram();
        param.InstanceObject = NextObject;
        param.RevealPosition = GameObject.Find("InstancePosition").transform.position;
        param.ParentObject = GameObject.Find("GameArea");
        param.Scale = 1;
        param.ObjectName = "Object";
        im.Instance_Object(param);
        //DataScripts.CurrentKoma = im.Instance_Object(param);
        SetNextFruit();
    }

    public void FinishGame()
    {
        //turnbutton.SetActive(false);
        //finishMenu.SetActive(true);
    }
}
