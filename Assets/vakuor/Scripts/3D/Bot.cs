using System;
using UnityEngine;

namespace vakuor.Scripts
{
    public class Bot : MonoBehaviour
    {
        private ActionHandler handler;
        private Fadeable fadeable;
        private void Awake()
        {
            handler = GetComponent<ActionHandler>();
            if(handler==null) throw new Exception("No action handler");
            
            fadeable = GetComponent<Fadeable>();
            if(fadeable==null) throw new Exception("No fadeable");

            handler.OnStart = () => { fadeable.Fade(true); };
            handler.OnEnd = () => { fadeable.Fade(false); gameObject.SetActive(false); };
        }
    }
}