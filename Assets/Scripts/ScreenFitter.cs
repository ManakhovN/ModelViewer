using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFitter : MonoBehaviour {
    [SerializeField] Camera cam;
    [SerializeField] Transform modelHandler;
    Transform model;
    MeshFilter[] meshFilters;
    
    public void ChangeModel(GameObject go) {
        if (model != null)
            Destroy(model.gameObject);
        model = go.transform;
        go.transform.position = Vector3.zero;
        modelHandler.transform.localScale = Vector3.one;
        model.SetParent(modelHandler);
        FitScreen();
    }

    public void FitScreen() {
        meshFilters = model.GetComponentsInChildren<MeshFilter>();        
        model.transform.localPosition = new Vector3(0f, -ModelUtils.CalculateCenter(meshFilters).y, -ModelUtils.GetClosestZ(meshFilters));
        var maxPoint = ModelUtils.GetBoundMax(meshFilters);
        var minPoint = ModelUtils.GetBoundMin(meshFilters);
        var screenPointMax = cam.WorldToViewportPoint(maxPoint);
        var screenPointMin = cam.WorldToViewportPoint(minPoint);
        float dy = Mathf.Abs(screenPointMax.y - screenPointMin.y);
        float dx = Mathf.Abs(screenPointMax.x - screenPointMin.x);
        float scale = 0.9f / (dy<dx?dx:dy);
        modelHandler.transform.localScale = Vector3.one * scale;
    }


   
}
