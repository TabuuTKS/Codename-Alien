using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DailogueManager : MonoBehaviour
{
    [SerializeField] GameObject DailoguePanel;
    [SerializeField] TMP_Text DailogueBox;

    private Queue<string> Sentences;
    void Start()
    {
        Sentences = new Queue<string>();
    }

    private void Update()
    {
        if (DailoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDailogue(Dailogue dailogue)
    {
        Time.timeScale = 0;
        DailoguePanel.SetActive(true);
        Sentences.Clear();
        foreach (string sentence in dailogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDailogue();
            return;
        }
        else
        {
            string sentence = Sentences.Dequeue();
            DailogueBox.text = sentence;
        }
    }

    void EndDailogue()
    {
        Time.timeScale = 1;
        DailoguePanel.SetActive(false);
    }
}
