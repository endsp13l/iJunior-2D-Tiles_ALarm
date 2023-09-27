using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmZone _alarmZone;

    private float _basicVolume = 0f;
    private float _maxVolume = 1f;
    private float _volumeChangeSpeed = 0.25f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _alarmZone = GetComponentInChildren<AlarmZone>();
    }

    private void Update()
    {
        if (_alarmZone.IsInvasion)
        {
            _animator.SetBool("IsInvasion", true);

            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeChangeSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("IsInvasion", false);

            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, _basicVolume, _volumeChangeSpeed * Time.deltaTime);
        }
    }
}