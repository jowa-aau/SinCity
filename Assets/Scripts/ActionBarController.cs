using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionBarController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ISelectHandler
{
    private static GameObject item;
    private Vector2 startPosition;
    private string eventName;
    
    //Buttons
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    // Start drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = GameObject.Find("ActionTarget");
        item.transform.localScale = new Vector3(1,1,1);
    }

    // dragging
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            item.transform.position = Input.mousePosition;
        }
    }

    // drop event
    public void OnEndDrag(PointerEventData eventData)
    {
       startEvent(eventData.position);
    }

    // start Event @ position
    void startEvent(Vector2 position)
    {
        Debug.Log("start event '" + eventName + "' @ " + position);
        
        // remove references
        eventName = null;
        item.transform.localScale = new Vector3(0, 0, 0);
        item = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        eventName = this.button.name;
    }
}
