using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas _mainCanvas;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor * 2;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
