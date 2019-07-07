using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

    [SerializeField]
    private AudioSource _clip;
    private Animator _anim;

    public bool _flag;
    float _phi;
    float _a;
    // Start is called before the first frame update
    void Start()
    {
        _clip = GetComponent<AudioSource>();
        _flag = false;
        _anim = GetComponent<Animator>();
        _a=0f;
        _phi=Mathf.PI/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(_flag)
        {
            if(!_clip.isPlaying)
            {
                _clip.Play();
            }
            if(_a<1.05f)
            {
                var dir = new Vector3(Mathf.Cos(_phi),transform.position.y,Mathf.Sin(_phi));
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),1);
                _anim.SetBool("isRunning",true);
                transform.position = new Vector3(_a*Mathf.Cos(_phi),transform.position.y,_a*Mathf.Sin(_phi));
                _a+=0.05f;

            }
            if(_a>1f)
            {
                var dir = new Vector3(Mathf.Cos(_phi),transform.position.y,Mathf.Sin(_phi));
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),1);
                transform.Rotate(new Vector3(0,-90,0),Space.World);
                transform.position = new Vector3(_a*Mathf.Cos(_phi),transform.position.y,_a*Mathf.Sin(_phi));
                _phi+=2*Mathf.PI/180;
            }
        }
        if(!_flag)
        {
            if(_clip.isPlaying)
            {
                _clip.Stop();
            }
            if(_a>0f)
            {
                var dir = new Vector3(Mathf.Cos(_phi),transform.position.y,Mathf.Sin(_phi));
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),1);
                transform.Rotate(new Vector3(0,180,0),Space.World);
                transform.position = new Vector3(_a*Mathf.Cos(_phi),transform.position.y,_a*Mathf.Sin(_phi));
                _a-=0.05f;
            }
            else
            {
                 _anim.SetBool("isRunning",false);
                 _phi+=Mathf.PI;
            }
        }
    }

    public void StartARButton()
    {
        if(_flag)
        {
            _flag=false;
        }
        else
        {
            _flag = true;
        }
    }
    public void GoBackToMenu()
    {
        _flag = false;
    }
}
