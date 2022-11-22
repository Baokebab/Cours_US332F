using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptEnterScript : MonoBehaviour

{ 
    [SerializeField] Character _player;
    AudioReverbFilter _reverbFilter;
    AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _reverbFilter = _player.GetComponent<AudioReverbFilter>();
        _source = _player.HeartbeatSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (_reverbFilter.reverbPreset == AudioReverbPreset.Stoneroom)
        {
            _reverbFilter.reverbPreset = AudioReverbPreset.StoneCorridor;
            _source.clip = _player.HeartBeatMusic[1];
            _source.Play();
        }
        else
        {
            _reverbFilter.reverbPreset = AudioReverbPreset.Stoneroom;
            _source.clip = _player.HeartBeatMusic[2];
            _source.Play();
        }

    }
}
