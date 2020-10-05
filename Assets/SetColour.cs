using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColour : MonoBehaviour
{
    //0 Hide, 1 Me, 2 You
    public Color[] colors;
    
    public GameObject chatBubble;

    public void SetColor(int i)
    {
        chatBubble.GetComponent<SpriteRenderer>().color = colors[i];
    }
}
