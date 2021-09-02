using UnityEngine;
using vakuor.Scripts;

public class ActionStateMachine : StateMachineBehaviour
{
    [SerializeField] private bool invokeOnStart;
    [SerializeField] private bool invokeOnEnd;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(invokeOnStart) animator.GetComponent<ActionHandler>()?.Invoke(ActionType.Start);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(invokeOnEnd) animator.GetComponent<ActionHandler>()?.Invoke(ActionType.End);
    }
}
