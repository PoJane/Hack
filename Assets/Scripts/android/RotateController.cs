using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateController : ScrollRect
{
    public float radius;
    public GameObject player;
    public int sceneIndex;
    public Vector2 controllerPosition;

    protected override void Start()
    {
        base.Start();

        radius = (transform as RectTransform).sizeDelta.x * 0.45f;

        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        controllerPosition = content.anchoredPosition;

        if (controllerPosition.magnitude > radius)
        {
            controllerPosition = controllerPosition.normalized * radius;
            SetContentAnchoredPosition(controllerPosition);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        

    }

    public Vector2 getControllerPos()
    {
        return controllerPosition;
    }

}

