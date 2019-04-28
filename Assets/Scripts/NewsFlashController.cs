using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class NewsFlashController : MonoBehaviour
{

    private string message = "";
                             
    public float scrollSpeed = 80;
    private bool isVisible = true;

    private List<string>news = new List<string>
    {
        "My boss can write his own news items, I quit!",
        "DAVE, DON'T FORGET TO REPLACE THIS WITH ACTUAL TEXT!",
        "Karen, I always wanted to tell you how I feel. Please call me!",
        "Koalas demand recognition as Ants.",
        "Local Ant wins Game Jam.",
        "Police is satisfied: Only hundreds severely injured after sports game."
    };

    private void Start()
    {
        this.message = randomString();
    }

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
        if (messageRect.x < -Screen.width)
        {
            message = randomString();
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

    private string randomString()
    {
        int randomIndex = Random.Range(0, news.Count);
        return news[randomIndex];
    }
    
    // is visiblel?
    public bool IsVisible => isVisible;
}
