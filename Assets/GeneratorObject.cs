using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Null))]
public class GeneratorObject : MonoBehaviour {

    private PlatformGenerator _gen;
    
    private void Start() {
        _gen = new PlatformGenerator();
    }

    private void Update() {
        _gen.AutomaticPlatformPerformanceOptimizationAndGenerationTick();
    }
}