using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicModelInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform modelHandler;
    protected Transform currentModel;
    protected Vector3 position;
    protected Camera cam;
    protected float zDistance;
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        currentModel = modelHandler.GetChild(0);
        position = currentModel.position;
        cam = Camera.main;
        zDistance = cam.WorldToScreenPoint(currentModel.position).z;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount <= 1)
            OnOneFingerDrag(eventData);
        else
            OnTwoFingersDrag(eventData);
    }

    public virtual void OnOneFingerDrag(PointerEventData eventData) { }

    public virtual void OnTwoFingersDrag(PointerEventData eventData) { }

    public virtual void OnEndDrag(PointerEventData eventData) { }
}