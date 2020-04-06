using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text speakerName;// field that will show who is speaking
    public Text convoContent;//field that will show the dialog
    public GameObject dialogPanel;//reference to the dialog panel so we can make it appear

    private Queue<string> sentences;//data structure that allows you to only add items to
                                    // end and remove from the begining (First in, First out)

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); //create our queue from sentences  
    }
    public void StartDialog(Dialog dialog)
    {
        Debug.Log("talk to" + dialog.name);
        speakerName.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndConvo();
            return;
        }
        string sentence = sentences.Dequeue();
        convoContent.text = sentence;
        Debug.Log("Line is" + sentence);

    }
    public void EndConvo()
    {
        Debug.Log("Reached end of convo");
        dialogPanel.SetActive(false);
    }
}
