using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource clipPlayer;
    public AudioClip audioClip;
    public AnimationCurve fadeIn;
    private void Start()
    {
        clipPlayer.clip = audioClip;
        clipPlayer.loop = true;
        clipPlayer.Play();
        StartCoroutine("FadeInMusic");
    }
    IEnumerator FadeInMusic()
    {
        float secs = 0;
        while (secs < 2)
        {
            clipPlayer.volume = fadeIn.Evaluate(secs);
            secs += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
