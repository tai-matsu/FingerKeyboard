using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.CognitiveServices.Speech;
using System;
using TMPro;

public class SpeechToTextTMP : MonoBehaviour
{

    [SerializeField] private string subscriptionKey;
    [SerializeField] private string region;
    [SerializeField] private TextMeshProUGUI quesWord;

    private SpeechConfig config;
    private string speechSynthesisLanguage = "ja-JP";


    // Start is called before the first frame update
    void Start()
    {
        config = SpeechConfig.FromSubscription(subscriptionKey, region);
        config.SpeechSynthesisLanguage = speechSynthesisLanguage;
        config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Raw16Khz16BitMonoPcm);
    }


    public async void SynthesizeAudioAsync()
    {
        try
        {
            using var synthesizer = new SpeechSynthesizer(config, null);
            var speakText = quesWord.text[quesWord.text.Length - 1].ToString();
            var result = await synthesizer.SpeakTextAsync(speakText);

            var audioSource = gameObject.AddComponent<AudioSource>();
            var sampleCount = result.AudioData.Length / 2;
            var audioData = new float[sampleCount];
            for (var i = 0; i < sampleCount; ++i)
            {
                audioData[i] = (short)(result.AudioData[i * 2 + 1] << 8 | result.AudioData[i * 2]) / 32768.0F;
            }

            var audioClip = AudioClip.Create("SynthesizedAudio", sampleCount, 1, 16000, false);
            audioClip.SetData(audioData, 0);
            audioSource.clip = audioClip;
            audioSource.Play();

            Debug.Log("AudioSynthesized");

        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
