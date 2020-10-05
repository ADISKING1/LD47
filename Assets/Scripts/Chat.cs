using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public SetColour setColour;

    public List<GameObject> texts = new List<GameObject>();

    public GameObject Me, You;

    public bool isConvo = false;

    private GameObject sms;

    public void StartConversation(Conversation convo)
    {
        isConvo = true;

        ClearChat();

        StartCoroutine(Chatting(convo));
    }

    IEnumerator Chatting(Conversation convo)
    {
        for(int i = 0; i < convo.sentences.Length; i++)
        {
            if (i % 2 == 0)
            {
                sms = Instantiate(Me, transform);
                setColour.SetColor(1);
            }
            else
            {
                sms = Instantiate(You, transform);
                setColour.SetColor(2);
            }

            sms.GetComponent<ChatText>().setChatText(convo.sentences[i]);
            texts.Add(sms);
            yield return new WaitForSeconds(2f);
        }
        setColour.SetColor(0);
        isConvo = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Button>().interactable = true;
    }

    IEnumerator WaitForKeyDown()
    {
        while (!(Input.GetButtonDown("Fire1") || Input.touchCount > 1))
            yield return new WaitForSeconds(0.2f);
    }

    public void ClearChat()
    {
        foreach (GameObject chatText in texts)
        {
            Destroy(chatText);
        }
        texts.Clear();
        Debug.Log("Chats Cleared");
    }
}
