using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Null))]
public class GeneratorObject : MonoBehaviour {

    private PlatformGenerator _gen;
    
    private void Start() {
        _gen = new PlatformGenerator();
        for (int i = 0; i < 10; i ++)
            _gen.GenerateNext();
    }
}