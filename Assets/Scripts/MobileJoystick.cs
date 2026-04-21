using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform bg;
    public RectTransform handle;

    Vector2 input = Vector2.zero;

    public float Horizontal() { return input.x; }
    public float Vertical() { return input.y; }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            bg, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= (bg.sizeDelta.x / 2);
            pos.y /= (bg.sizeDelta.y / 2);

            input = new Vector2(pos.x, pos.y);
            input = (input.magnitude > 1) ? input.normalized : input;

            handle.anchoredPosition = new Vector2(
                input.x * (bg.sizeDelta.x / 2),
                input.y * (bg.sizeDelta.y / 2)
            );
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}