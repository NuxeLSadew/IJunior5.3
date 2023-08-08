using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class RandomAudioClipPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnShot()
    {
        int index = Random.Range(0, _audioClips.Length);
        AudioClip audioClip = _audioClips[index];

        _audioSource.PlayOneShot(audioClip);
    }
}
