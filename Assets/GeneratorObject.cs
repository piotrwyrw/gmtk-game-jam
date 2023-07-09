using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Null))]
public class GeneratorObject : MonoBehaviour {

    private PlatformGenerator _gen;

    [SerializeField] private int count;
    
    private void Start() {
        _gen = new PlatformGenerator();
        for (int i = 0; i < count; i ++)
            _gen.GenerateNext();
    }

    private void Update() {
        _gen.AutomaticPlatformPerformanceOptimization();
    }
}