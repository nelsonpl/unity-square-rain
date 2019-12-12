using UnityEngine;
using System.Collections;
using Assets.Scripts.Entities;

public class MultimediaController : MonoBehaviour
{
    public AudioClip SoundGesture;
    public AudioClip SoundGameOver;
    public AudioClip SoundCreate;
    public AudioClip SoundPlay;

    private static MultimediaController _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void ExecuteSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }

    public static void ExecuteGesture()
    {
        if (_instance == null) return;
        _instance.ExecuteSound(_instance.SoundGesture);
    }

    public static void ExecuteGameOver()
    {
        if (_instance == null) return;
        _instance.ExecuteSound(_instance.SoundGameOver);
    }

    public static void ExecuteCreate()
    {
        if (_instance == null) return;
        _instance.ExecuteSound(_instance.SoundCreate);
    }

    public static void ExecutePlay()
    {
        if (_instance == null) return;
        _instance.ExecuteSound(_instance.SoundPlay);
    }
}
