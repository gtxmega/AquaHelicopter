using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnClick = new UnityEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

}
