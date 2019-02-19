using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelPinchingInput : BasicModelInput
{
    [SerializeField] float perspectiveZoomSpeed = 0.5f;
    public override void OnTwoFingersDrag(PointerEventData eventData)
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        Debug.Log("pinch " + deltaMagnitudeDiff);
        cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);
    }
}
