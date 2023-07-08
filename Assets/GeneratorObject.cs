using System;
using UnityEngine;

public class GeneratorObject : MonoBehaviour {

    private PlatformGenerator _gen;
    
    private void Start() {
        _gen = new PlatformGenerator();
        
        // Generate some platforms lol
        for (int i = 0; i < 10; i ++)
            _gen.GenerateNext();
    }
}