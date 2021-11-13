using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogueData;

    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogueData);
    }
}
