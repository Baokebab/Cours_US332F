using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearBeat : MonoBehaviour
{

    public int BeatIndex = 0;
    [SerializeField] Character _player;
    bool FadingOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FadingOut)
        {
            if (_player.HeartbeatSource.volume > 0.1f) _player.HeartbeatSource.volume -= 0.1f;
            else
            {
                FadingOut = false;
                _player.HeartbeatSource.volume = 1;
                _player.HeartbeatSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FadingOut = true;
            _player.HeartbeatSource.clip = _player.HeartBeatMusic[BeatIndex];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(BeatIndex == 3)
        {
            FadingOut = true;
            _player.HeartbeatSource.clip = _player.HeartBeatMusic[2];
        }
    }
}
