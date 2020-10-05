using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatText : MonoBehaviour
{
    public Text chatText;


    public float value, scale, factor;
    public void setChatText(string text)
    {
        chatText.text = text;
    }

    private void Start()
    {
        value = 0;
        factor = 2;
    }

    private void FixedUpdate()
    {
        scale = Mathf.Clamp(value, 0, 1);
        value += Time.deltaTime * factor;
        factor *= 1.005f;
        GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
    }
}
