using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MessageDialog : MonoBehaviour
{
    public Button negativeButton;
    public Button positiveButton;
    public Text textLabel;

    public void OnPositiveClick(UnityAction call)
    {
        if (positiveButton == null)
            return;
        if (positiveButton.onClick != null)
            positiveButton.onClick.RemoveAllListeners();
        positiveButton.onClick.AddListener(call);
    }

    public void OnNegativeClick(UnityAction call)
    {
        if (negativeButton == null)
            return;
        if (negativeButton.onClick != null)
            negativeButton.onClick.RemoveAllListeners();
        negativeButton.onClick.AddListener(call);
    }

    public void SetText(string text)
    {
        textLabel.text = text;
    }

    public void SetVisibility(bool visibility)
    {
        this.gameObject.SetActive(visibility);
    }
    static Dictionary<string, Object> prefabs = new Dictionary<string, Object>();
    public static MessageDialog Instantiate(string resourcePath)
    {
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        Object prefab;
        if (!prefabs.ContainsKey(resourcePath))
            prefabs.Add(resourcePath, Resources.Load(resourcePath));

        prefab = prefabs[resourcePath];

        GameObject dialog = Instantiate(prefab, canvas.transform) as GameObject;
        return dialog.GetComponent<MessageDialog>();
    }
}
