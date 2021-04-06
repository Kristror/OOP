using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public sealed class Interaction
{
    public GameObject _body;
    public Interaction(PlayerMove player)
    {
        _body = player.gameObject;
    }
    public void SizeChange(float time)
    {
        _body.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void ChangeColor(float time)
    {
        Color _material = _body.GetComponent<Renderer>().material.color;
        _body.GetComponent<Renderer>().material.color = new Color(_material.r, _material.g + 100, _material.b);        
    }

    public void NormalColor()
    {
        Color _material = _body.GetComponent<Renderer>().material.color;
        _body.GetComponent<Renderer>().material.color = new Color(_material.r, _material.g - 100, _material.b);
    }
    public void NormalSize()
    {
        _body.transform.localScale = Vector3.one;
    }
}
