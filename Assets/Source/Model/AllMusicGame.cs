using System.Collections;
using UnityEngine;

public class AllMusicGame : MonoBehaviour
{
    private const float Delay = 0.6f;

    public static AllMusicGame Singleton { get; private set; }

    [SerializeField] private AudioClip _wingMusic, _SwooshingMusic, _pointsMusic, _dieMusic;

    private AudioSource _effects;
    private AudioSource _points;

    public void PLayWingMusic() 
    => StartMusic(_wingMusic);

    public void PLaySwooshingMusic()
   => StartMusic(_SwooshingMusic);

    public void PLayPointsMusic()
    => _points.Play();

    public void PLayDieMusic()
    { 
        StartMusic(_dieMusic);
        StartCoroutine(DisableEffects());

        IEnumerator DisableEffects()
        {
            yield return new WaitForSeconds(Delay);
            _effects.enabled = false;
        }
    }

    public void InitAudioSource(AudioSource effects, AudioSource points)
    { 
        _effects = effects;
        _points = points;
        _points.clip = _pointsMusic;
    }

    private void StartMusic(AudioClip music)
    {
        _effects.clip = music;
        _effects.Play();
    }

    private void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
