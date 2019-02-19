using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelViewController : MonoBehaviour {
    [SerializeField] ScreenFitter screenFitter;
    public void InstantiateModel(Object obj) {
        GameObject go = Instantiate(obj) as GameObject;
        go.name = obj.name;
        screenFitter.ChangeModel(go);
    }
}
