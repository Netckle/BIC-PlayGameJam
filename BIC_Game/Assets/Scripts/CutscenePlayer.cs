using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    public Fade fade;
    public DialogueLoader dialogueLoader;
    public string targetScene;

    private void Start()
    {
        StartCoroutine(ShowCutscene());
    }

    IEnumerator ShowCutscene()
    {
        yield return new WaitForSeconds(fade.fadeTime);

        dialogueLoader.StartDialogue(() => { StartCoroutine(DialogueCallback()); });
    }

    private IEnumerator DialogueCallback()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(fade.fadeTime);

        SceneManager.LoadScene(targetScene);
    }
}
