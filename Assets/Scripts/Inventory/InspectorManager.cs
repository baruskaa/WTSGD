using System;
using UnityEngine;
using UnityEngine.UI;

public class InspectorManager : MonoBehaviour
{
    public GameObject inspectPanel;
    public Image inspectImage;

    public Action onInspectClosed;

    void Start()
    {
        HideInspectPanel();
    }

    public void ShowInspectPanel(Sprite image)
    {

        if (inspectImage != null)
        {
            inspectImage.sprite = image;
            inspectImage.gameObject.SetActive(image != null);
        }

        inspectPanel.SetActive(true);
    }

    public void HideInspectPanel()
    {
        inspectPanel.SetActive(false);

        // Safely invoke the callback once
        if (onInspectClosed != null)
        {
            onInspectClosed.Invoke();
            onInspectClosed = null;
        }
    }
}
