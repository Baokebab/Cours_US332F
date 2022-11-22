using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    [SerializeField] AudioSource _audioSourceMusic;
    [SerializeField] AudioSource _audioSourceParasite;
    [SerializeField] Transform _player;
    [SerializeField] AudioClip[] _radioList;
    [SerializeField] AudioClip[] _parasiteList;
    [SerializeField] float distanceParasite;
    int _indexRadio = 0, _indexParasite = 0;
    public float coolDownParasite = 20f;
    public float TimerParasite;
    public bool doorhasClosed = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_audioSourceParasite.isPlaying)
        {
            _audioSourceMusic.volume = 0.1f;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, _player.position, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
                if (_audioSourceParasite.volume <= 1f && (hit.collider.name == "PLAYER" || !doorhasClosed))
                {
                    _audioSourceParasite.volume += 0.035f;
                }
                else
                {
                    if (doorhasClosed && _audioSourceParasite.volume > 0.19f)
                    {
                        _audioSourceParasite.volume -= 0.1f;
                    }
                }
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, _player.position, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.cyan);
                if (_audioSourceMusic.volume <= 1f && (hit.collider.name == "PLAYER" || !doorhasClosed))
                {
                    _audioSourceMusic.volume += 0.035f;
                }
                else
                {
                    if (doorhasClosed && _audioSourceMusic.volume > 0.19f)
                    {
                        _audioSourceMusic.volume -= 0.1f;
                    } 
                }
            }
        }
        if(!_audioSourceMusic.isPlaying)
        {
            _indexRadio = (_indexRadio + 1) % _radioList.Length;
            _audioSourceMusic.clip = _radioList[_indexRadio];
            _audioSourceMusic.Play();
        }
        if(Vector3.Distance(_player.position, transform.position) < distanceParasite)
        {
            TimerParasite -= Time.deltaTime;
            if(TimerParasite <= 0)
            {
                TimerParasite = coolDownParasite;
                _audioSourceParasite.clip = _parasiteList[_indexParasite];
                _audioSourceParasite.Play();
                _indexParasite = (_indexParasite + 1) % _parasiteList.Length;
            }
        }
        
    }
}
