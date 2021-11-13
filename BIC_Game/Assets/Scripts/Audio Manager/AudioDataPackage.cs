using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Data", menuName = "Scriptable Object/Audio Data")]
public class AudioDataPackage : ScriptableObject
{
    public List<AudioData> audioDatas = new List<AudioData>();

    public AudioClip SearchAudioFromPackage(string name)
    {
        AudioClip target = null;

        foreach(AudioData audioData in audioDatas)
        {
            Debug.Log(audioData.name + " " + name);
            if (audioData.name == name)
            {
                target = audioData.clip;
                return target;
            }
        }

        if (target == null)
            Debug.LogWarning(name + " audio file is not exicst.");

        return target;
    }
}
