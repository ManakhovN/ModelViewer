using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsPanelGenerator : MonoBehaviour {
    [SerializeField] GameObject prefab;
    [SerializeField] Transform content;
    [SerializeField] ModelViewController modelViewController;
    [SerializeField] Button showPanelButton;
    RectTransform rectTransform;
    void Start () {
        StartCoroutine(GetAllModels());
        rectTransform = GetComponent<RectTransform>();
        showPanelButton.onClick.AddListener(ShowPanel);
    }

    IEnumerator GetAllModels() {
        var models = ModelUtils.LoadFromResources();
        for (int i = 0; i < models.Length; i++) {
            GenerateUIItem(models[i]);
            yield return new WaitForEndOfFrame();
        }
    }

    private void GenerateUIItem(UnityEngine.Object obj)
    {
        GameObject item = GameObject.Instantiate(prefab, content);
        item.GetComponent<ModelsUIElement>().Init(obj, ()=>OnItemClick(obj));
    }

    private void OnItemClick(UnityEngine.Object obj)
    {
        if (obj == null)
            return;
        modelViewController.InstantiateModel(obj);
        HidePanel();
    }

    public void HidePanel() {
        StartCoroutine(MoveAnchoredPositionTo(Vector2.down * rectTransform.rect.height, 5000f));
    }


    public void ShowPanel() {
        StartCoroutine(MoveAnchoredPositionTo(Vector2.zero, 5000f));
    }


    public IEnumerator MoveAnchoredPositionTo(Vector2 target, float speed) {
        while (!rectTransform.anchoredPosition.Equals(target))
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, target, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
