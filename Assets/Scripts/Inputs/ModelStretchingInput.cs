using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelStretchingInput : BasicModelInput {
    [SerializeField] float multiplier = 0.01f;
    public override void OnOneFingerDrag(PointerEventData eventData)
    {
        this.currentModel.localScale += new Vector3(0f,eventData.delta.y * multiplier,0f);
    }
}
