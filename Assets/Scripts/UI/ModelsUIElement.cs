using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModelsUIElement : MonoBehaviour {
    [SerializeField] private Text title;
    [SerializeField] private Image preview;
    [SerializeField] private Button button;

    public void Init(Object obj, UnityAction action) {
        title.text = obj.name;
        preview.sprite = PreviewUtils.LoadPreview(obj);
        button.onClick.AddListener(action);
    }

    public void SetProgress(float progress) {
        preview.type = Image.Type.Filled;
        preview.fillAmount = progress;
    }
}
