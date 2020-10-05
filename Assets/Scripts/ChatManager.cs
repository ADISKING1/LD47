using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    public Chat chat;

    public Conversation[] convos;

    public List<Conversation> activeConvos = new List<Conversation>();

    public Text buttonText;

    public Text title;
    [TextArea(8, 15)]
    public string endQuote;

    private bool canEnd = false;
    private bool canRe = false;

    public void Start()
    {
        activeConvos.Clear();
        activeConvos = convos.ToList();
    }

    public void InvokeConvo()
    {
        int rand = UnityEngine.Random.Range(0, activeConvos.Count);
        if (chat.isConvo == false && activeConvos.Count != 0)
        {
            chat.StartConversation(activeConvos[rand]);
            activeConvos.RemoveAt(rand);
            buttonText.text = "Next";
            GameObject.FindGameObjectWithTag("Player").GetComponent<Button>().interactable = false;
        }
        else if (activeConvos.Count <= 0)
        {
            if(canEnd == false)
            {
                chat.ClearChat();
                buttonText.text = "End";
                canEnd = true;
            }
            else // end screen
            {
                Debug.Log("Fin");
                EndScreen();
            }
        }
    }

    public void EndScreen()
    {
        if(canRe == false)
        {
            title.text = endQuote;
            title.alignment = TextAnchor.MiddleCenter;
            buttonText.text = "Restart";
            canRe = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Button>().interactable = false;
            StartCoroutine(MakeInter());
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator MakeInter()
    {
        yield return new WaitForSeconds(3f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Button>().interactable = true;
    }
}
