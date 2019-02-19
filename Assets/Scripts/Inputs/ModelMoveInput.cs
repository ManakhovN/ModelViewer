using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelMoveInput : BasicModelInput
{
    [SerializeField] float speed;
    public override void OnOneFingerDrag(PointerEventData eventData)
    {
        currentModel.position += (Vector3)eventData.delta*speed;
    }
}
