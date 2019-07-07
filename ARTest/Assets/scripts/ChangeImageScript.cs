using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageScript : MonoBehaviour
{
    public RawImage _run;
    public RawImage _idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()
    {
        if(_run.isActiveAndEnabled)
        {
            _run.enabled=false;
            _idle.enabled=true;
        }
        else
        {
            _run.enabled=true;
            _idle.enabled=false;
        }
    }
}
