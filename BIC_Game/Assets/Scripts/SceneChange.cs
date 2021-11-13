using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string targetScene;
    Fade fade;

    private void Start()
    {
        fade = GetComponent<Fade>();
    }

    public void ChangeScene()
    {
        StartCoroutine(ChangeWithFade());
    }

    private IEnumerator ChangeWithFade()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene(targetScene);
    }
}
