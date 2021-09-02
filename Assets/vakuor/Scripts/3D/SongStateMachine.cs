using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongStateMachine : StateMachineBehaviour
{
    [SerializeField] protected AudioClip audioClip;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!TryPlaySong(animator)) Debug.Log("Error while playing sound!" + animator.gameObject.name);
    }

    private bool TryPlaySong(Animator animator)
    {
        var audioSource = animator.gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
            return false;

        audioSource.clip = audioClip;
        audioSource.Play();
        return true;
    }
}