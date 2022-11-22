using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip[] _ghostSoundList;
    AudioSource _audioSource;
    public float TimeInterval = 7.5f;
    [SerializeField] Transform BasePosition;
    float Timer;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Timer = TimeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            Timer = TimeInterval;
            _audioSource.PlayOneShot(_ghostSoundList[Random.Range(0,_ghostSoundList.Length)]);
            transform.position =  4 * Random.onUnitSphere + BasePosition.position ;
        }
    }
}
