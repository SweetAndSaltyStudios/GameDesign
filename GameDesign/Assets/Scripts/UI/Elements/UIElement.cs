using UnityEngine;
using UnityEngine.EventSystems;

namespace Sweet_And_Salty_Studios
{
    public class UIElement : MonoBehaviour,
        IPointerEnterHandler,
        IPointerDownHandler,
        IPointerExitHandler,
        IPointerUpHandler,
        IPointerClickHandler
    {

        public virtual void OnPointerEnter(PointerEventData eventData)
        {

        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
           
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
           
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
           
        }
    }
}