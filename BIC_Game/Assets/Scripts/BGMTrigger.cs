using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    public string bgmName;
    private AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();
        AudioManager.Instance.SimplePlaySound(bgmName, source, 1f, true);
    }

    public void StopBGM()
    {
        source.Stop();
    }
}
