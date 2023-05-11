using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseUI : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField] Image image;

    private void Update()
    {
        FollowMouse();
    }

    public void FollowMouse()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out pos);

        transform.position = canvas.transform.TransformPoint(pos);

    }

    public void SetImage(Sprite newImage)
    {
        image.sprite = newImage;
        OnOff(true);
    }

    public void OnOff(bool status)
    {
        image.gameObject.SetActive(status);
    }
}
