using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFruit : MonoBehaviour
{
    public bool isRelease = false;
    [SerializeField] private GameObject NextObject;
    [SerializeField] private int thisScore = 0;
    private bool isMergeFlag = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colobj = collision.gameObject;

        if (NextObject == null)
        {
            if (colobj.CompareTag(this.gameObject.tag))
            {
                if (colobj.GetComponent<BaseFruit>().isMergeFlag == true) return;
                isMergeFlag = true;

                Destroy(collision.gameObject);
                Destroy(gameObject);

                DataScripts.Score += thisScore;
                return;
            }
        }

        if (colobj.CompareTag(this.gameObject.tag))
        {
            if (colobj.GetComponent<BaseFruit>().isMergeFlag == true) return;
            isMergeFlag = true;
            var im = InstanceManager.Instance;

            var param = new InstanceManager.instancePram();
            param.InstanceObject = NextObject;
            param.RevealPosition = (transform.position + colobj.transform.position) / 2;
            param.ParentObject = GameObject.Find("GameArea");
            param.Scale = 1;
            param.ObjectName = "Object";
            GameObject instance = im.Instance_Object(param);
            Destroy(instance.GetComponent<ControllManager>());
            instance.GetComponent<Rigidbody2D>().simulated = true;
            instance.GetComponent<BaseFruit>().isRelease = true;

            Destroy(collision.gameObject);
            Destroy(gameObject);

            DataScripts.Score += thisScore;
        }
    }
}
