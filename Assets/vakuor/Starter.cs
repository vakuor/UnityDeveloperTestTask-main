using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject startHint;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            target.SetActive(true);
            startHint.SetActive(false);
        }
    }
}
