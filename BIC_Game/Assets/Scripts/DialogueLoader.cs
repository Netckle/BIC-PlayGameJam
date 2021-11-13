using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DialogueLoader : MonoBehaviour
{
    public DialogueData dialogueData;

    private void Start()
    {
        LoadDialogueData();
    }

    public void LoadDialogueData()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Dialogue_CH1.json");
        var data = JsonHelper.FromJson<Dialogue>(jsonString);

        foreach (var dialogue in data)
        {
            dialogueData.contents.Add(dialogue);
        }
    }

    public void StartDialogue(DialogueManager.Callback callback = null)
    {
        DialogueManager.Instance.StartDialogue(dialogueData, callback);
    }
}
