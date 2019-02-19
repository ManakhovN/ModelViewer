using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelRotationInput : BasicModelInput
{
    public override void OnOneFingerDrag(PointerEventData eventData)
    {
            currentModel.RotateAround(position, Vector3.up, eventData.delta.x);
            currentModel.RotateAround(position, Vector3.left, eventData.delta.y);
    }
}
