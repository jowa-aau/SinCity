using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsFlashController : MonoBehaviour
{

    private string message = "This is a test .... string !?! Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
                             "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat.";
    public float scrollSpeed = 80;
    private bool isVisible = true;
    
    public Rect messageRect;
 
    void OnGUI ()
    {
        if (this.scrollSpeed == 0)
        {
            scrollSpeed = 80;
        }
		
		
        if (!isVisible)
        {
            return;
        }
		
		
        // Set up the message's rect if we haven't already
        if (messageRect.width == 0) {
            Vector2 dimensions = GUI.skin.label.CalcSize(new GUIContent(message));
			
 
            // Start the message past the left side of the screen
            messageRect.x      =  dimensions.x;
            messageRect.width  =  dimensions.x;
            messageRect.height =  dimensions.y;
        }
 
        messageRect.x -= Time.deltaTime * scrollSpeed;
 
        // If the message has moved past the right side, move it back to the left
        if (messageRect.x < -Screen.width) {
            messageRect.x = messageRect.width;
        }
        
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
 
        GUI.Label(messageRect, message, style);
    }
    
    

    // 
    public void setMessage(string message)
    {
        this.message = message;
    }

    // show newsflash
    public void setVisible(bool isVisible)
    {
        this.isVisible = isVisible;
    }
    
    // is visiblel?
    public bool IsVisible => isVisible;
}
