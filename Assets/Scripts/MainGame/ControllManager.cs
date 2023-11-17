using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 mouse;
    private Vector3 target;
    private bool is_Touched = false;
    private bool is_falldown = false;
    public bool is_Sleeping = false;
    private bool InstanceOnce = false;

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        is_Touched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        is_Touched = false;
        is_falldown = true;
        this.GetComponent<Rigidbody2D>().simulated = true;

        //GameManagerにアクセス
        GameManager.Instance.MakeNextFruit();
    }

    void Update()
    {
        if (is_Touched && !is_falldown)
        {
            mouse = Input.mousePosition;
            target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
            target.y = transform.position.y;
            this.transform.position = target;
        }

        is_Sleeping = GetComponent<Rigidbody2D>().IsSleeping();

        if (is_Sleeping && !InstanceOnce)
        {
            GetComponent<BaseFruit>().isRelease = true;
            InstanceOnce = true;
        }
    }
}