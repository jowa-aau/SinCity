using System.Collections;
using System.Collections.Generic;
using Framework.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionBarController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ISelectHandler
{
    private static GameObject item;
    private Vector2 startPosition;
    private string eventName;
    [SerializeField] private GameObject prefab;
    public AudioClip Fire;
    AudioSource audio;
    
    //Buttons
    private Button button;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        button = GetComponent<Button>();
    }

    // Start drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        item = GameObject.Find("ActionTarget");
        item.transform.localScale = new Vector3(2,2,1);
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
        Vector3 cursorpos = UnityEngine.Camera.main.ScreenToWorldPoint(InputManager.GetCursorPosition());
       startEvent(cursorpos);
    }

    // start Event @ position
    void startEvent(Vector3 position)
    {
        position.z = 0;
        Debug.Log("start event '" + prefab.gameObject.name + "' @ " + position);
        Instantiate(prefab, position, Quaternion.identity);
  
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
