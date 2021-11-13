using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string description;
    public string sprite;
}

[System.Serializable]
public class DialogueData
{
    public List<Dialogue> contents = new List<Dialogue>();
}

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    public Transform leftPos;
    public Transform rightPos;

    public float delay = 0f;

    public Image dialoguePanel;

    public Text name;
    public Text description;

    public Image talker;

    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    public delegate void Callback();
    private Callback callback = null;

    private void Start()
    {
        dialoguePanel.gameObject.SetActive(false);
        talker.gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogues, Callback callback = null)
    {
        this.callback = callback;

        name.text = "";
        description.text = "";

        talker.gameObject.SetActive(true);
        dialoguePanel.gameObject.SetActive(true);

        for (int i = 0; i < dialogues.contents.Count; i++)
        {
            dialogueQueue.Enqueue(dialogues.contents[i]);
        }
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        StopAllCoroutines();

        if (dialogueQueue.Count <= 0)
            EndDialogue();

        name.text = "";
        description.text = "";

        Dialogue dialogue = dialogueQueue.Dequeue();
        name.text = dialogue.name;
        Debug.Log("Sprites / " + dialogue.sprite);
        talker.sprite = Resources.Load("Sprites/" + dialogue.sprite, typeof(Sprite)) as Sprite;
        if (dialogue.sprite == "한우빈_기본" || dialogue.sprite == "스토피_기본")
        {
            talker.transform.position = leftPos.position;
        }
        else
        {
            talker.transform.position = rightPos.position;
        }
        
        StartCoroutine(TypeDialouge(dialogue.description));
    }

    private IEnumerator TypeDialouge(string description)
    {
        foreach (char c in description)
        {
            this.description.text += c;
            yield return new WaitForSeconds(delay);
        }
        this.description.text = description;
    }

    private void EndDialogue()
    {
        name.text = "";
        description.text = "";

        dialoguePanel.gameObject.SetActive(false);
        talker.gameObject.SetActive(false);

        if (callback != null)
        {
            callback();
            callback = null;
        }
    }
}
