using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmZone _alarmZone;

    private float _basicVolume = 0f;
    private float _maxVolume = 1f;
    private float _volumeChangeSpeed = 0.25f;

    private bool _isActive;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _alarmZone = GetComponentInChildren<AlarmZone>();

        _alarmZone.MovementDetected += TurnOn;
        _alarmZone.ZoneCleared += TurnOff;
    }

    private void OnDisable()
    {
        _alarmZone.MovementDetected -= TurnOn;
        _alarmZone.ZoneCleared -= TurnOff;
    }

    private void TurnOn()
    {
        _isActive = true;
        StopCoroutine(DecreaseVolume());
        StartCoroutine(IncreaseVolume());
    }

    private void TurnOff()
    {
        _isActive = false;
        StopCoroutine(IncreaseVolume());
        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        while (_isActive == true)
        {
            _animator.SetBool("IsInvasion", true);
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (_isActive == false)
        {
            _animator.SetBool("IsInvasion", false);
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, _basicVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}