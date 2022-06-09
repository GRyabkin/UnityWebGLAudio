using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class DownloadAudio: MonoBehaviour
{
    public Text inputText;
    public AudioSource audioSource;

    public void OnAudio1Click() {
        audioSource.Stop();
        var audioUrl = "https://unity-test-audio.s3.amazonaws.com/SoundHelix-Song-1.mp3";
        StartCoroutine(PlayAvatarAudio(audioUrl));
    }

    public void OnAudio2Click() {
        audioSource.Stop();
        var audioUrl = "https://unity-test-audio.s3.amazonaws.com/organfinale.mp3";
        StartCoroutine(PlayAvatarAudio(audioUrl));
    }

    public void OnAudio3Click() {
        audioSource.Stop();
        var audioUrl = "https://unity-test-audio.s3.amazonaws.com/LRMonoPhase4.mp3";
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
            audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
            audioSource.Play();
        }
    }
}
