using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    public UnityEvent onEndVideo;

    public VideoPlayer vid;

    void Start() { vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        onEndVideo.Invoke();
    }

}
