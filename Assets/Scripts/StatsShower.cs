using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsShower : MonoBehaviour {

    [SerializeField] Button showStatsButton;
    [SerializeField] Transform modelHandler;
	void Start () {
        showStatsButton.onClick.AddListener(ShowModelsStats);
	}

    private void ShowModelsStats()
    {
        MessageDialog message = MessageDialog.Instantiate("UI/StatsMessage");
        message.OnNegativeClick(() => Destroy(message.gameObject));
        message.SetText(ModelUtils.GetModelInfo(modelHandler.GetChild(0).gameObject));
    }
}
