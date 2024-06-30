using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    [SerializeField] private AudioClip[] _walkClips;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _dash;

    [SerializeField] private float _walkRate;

    private float _nextStep;

    public void Jump()
    {
        _source.PlayOneShot(_jump);
    }

    public void Dash()
    {
        _source.PlayOneShot(_dash);
    }

    public void Walk()
    {
        if(Time.time >= _nextStep)
        {
            _nextStep = Time.time + _walkRate;
            _source.PlayOneShot(_walkClips[Random.Range(0, _walkClips.Length)]);
        }
    }
}