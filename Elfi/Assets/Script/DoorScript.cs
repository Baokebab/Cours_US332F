using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioClip _doorOpen;
    [SerializeField] AudioClip _doorClose;
    AudioSource _audioSource;
    public float DoorOpenVolume;
    public float DoorCloseVolume;
    public RadioScript Radio;
    public bool isBasement;
    [SerializeField] Character _player;
    AudioSource _source;
    AudioReverbFilter _audioFilter;
    // Start is called before the first frame update
    void Start()
    {
        //Assignation de son propre animator en tant que variable pour pouvoir y accéder plus simplement
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioFilter = _player.GetComponent<AudioReverbFilter>();
        _source = _player.HeartbeatSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //déclence l'animation d'ouverture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("In", true);
        if (isBasement && _audioFilter.enabled == false)
        {
            _audioFilter.enabled = true;
            _source.clip = _player.HeartBeatMusic[1];
            _source.Play();
        }
        else
        {
            _audioFilter.enabled = false;
            _source.clip = _player.HeartBeatMusic[0];
            _source.Play();
        }
    }

    //déclence l'animation de fermeture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("In", false);
    }

    //Créer une fonction publique à appeler lors d'un animation event ?
    public void DoorOpen()
    {
        _audioSource.PlayOneShot(_doorOpen, DoorOpenVolume);
        Radio.doorhasClosed = false;
    }

    public void DoorClose()
    {
        _audioSource.PlayOneShot(_doorClose, DoorCloseVolume);
        Radio.doorhasClosed = true;
    }

}
