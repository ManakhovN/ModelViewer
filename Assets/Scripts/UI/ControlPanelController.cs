using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour {
    [SerializeField] BasicModelInput[] inputs;
	void Awake () {
        InitToggles();
	}

    private void InitToggles()
    {
        var toggles = transform.GetComponentsInChildren<Toggle>();

        for (int i = 0; i < inputs.Length; i++)
            inputs[i].enabled = (i == 0);

        for (int i = 0; i < inputs.Length; i++)
        {
            int id = i;
            toggles[i].onValueChanged.AddListener((isOn) => inputs[id].enabled = isOn);
        }
    }
}
