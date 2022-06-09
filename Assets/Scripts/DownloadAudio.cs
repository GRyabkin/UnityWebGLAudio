using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class DownloadAudio: MonoBehaviour
{
    public Text inputText;
    public AudioSource audioSource;

    public void OnAudio1Click() {
        var audioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3";
        StartCoroutine(PlayAvatarAudio(audioUrl));
    }

    public void OnAudio2Click() {
        var audioUrl = "https://www.kozco.com/tech/LRMonoPhase4.mp3";
        StartCoroutine(PlayAvatarAudio(audioUrl));
    }

    public void OnAudio3Click() {
        var audioUrl = "https://www.kozco.com/tech/organfinale.mp3";
        StartCoroutine(PlayAvatarAudio(audioUrl));
    }
    
    IEnumerator PlayAvatarAudio(string audioUrl)
    {
        var audioUri = new Uri(audioUrl);
        Debug.Log(audioUri);
        using UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(audioUri, AudioType.MPEG);
        yield return www.SendWebRequest();

        if (www.responseCode != 200 || www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
            audioSource.Play();
        }
    }
}
