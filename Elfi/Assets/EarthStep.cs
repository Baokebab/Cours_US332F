using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStep : MonoBehaviour
{
    [SerializeField] Character _player;
    [SerializeField] AudioSource _wind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player.isInside = false;
            _player.HeartbeatSource.Stop();
            _wind.Play();
        }
    }
}
