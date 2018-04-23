using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispSwarm : MonoBehaviour {

    private void OnEnable()
    {
        
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(0.5f);

    }
}

