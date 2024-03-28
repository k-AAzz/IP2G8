using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private Dictionary<string, AudioClip> audioClipDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        foreach (AudioClip clip in audioClips)
        {
            audioClipDictionary.Add(clip.name, clip);
        }
    }

    public void Start()
    {
        PlayAudio("BackgroundLoop");
    }

    public void PlayAudio(string fileName)
    {
        if (audioClipDictionary.ContainsKey(fileName))
        {
            AudioSource.PlayClipAtPoint(audioClipDictionary[fileName], Vector3.zero);
        }
        else
        {
            Debug.LogError("Audio clip with file name " + fileName + " not found!");
        }
    }
}


