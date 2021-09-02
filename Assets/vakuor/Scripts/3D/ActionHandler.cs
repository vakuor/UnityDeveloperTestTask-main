using System;
using UnityEngine;

namespace vakuor.Scripts
{
    public enum ActionType
    {
        Start,
        End
    }
    
    public class ActionHandler : MonoBehaviour
    {
        public Action OnStart { get; set; }
        public Action OnEnd { get; set; }

        public void Invoke(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.Start:
                {
                    OnStart?.Invoke();
                    break;
                }
                
                case ActionType.End:
                {
                    OnEnd?.Invoke();
                    break;
                }
            }
        }
    }
}