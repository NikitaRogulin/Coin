using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [SerializeField,Range(0,5)] private float _rotationSpeed;
    [SerializeField] private List<Color> colors;
    [SerializeField,Range(0,1)] private float _deltaT;
    private Renderer _renderer;
    private Material _material;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        SaveMaterial();
    }

    private void Update()
    {
        Rotate();
    }
    private void SaveMaterial()
    {
        var material = new Material(_material);
        _material = material;
        _renderer.material = _material;
    }
    private void Rotate()
    {
        var speed = GetSpeed();
        transform.Rotate(speed);
    }
    public void ChangeColor()
    {
        var tempColor = GetRandomColor();
        if (_material.color != tempColor)
        {
            _material.color = tempColor;
        }
        else
        {
            ChangeColor();
        }
    }
    private Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Count)];
    }

    private Vector3 GetSpeed()
    {
        var speed = Mathf.Sin(Time.time / _deltaT) * _rotationSpeed;
        return new Vector3(0, 0, speed);
    }
}

