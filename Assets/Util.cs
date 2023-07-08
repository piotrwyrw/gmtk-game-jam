
public class Util {
    public static float Random(float min, float max) {
        return UnityEngine.Random.Range(min, max);
    }
    
    public static bool Random() {
        float val = UnityEngine.Random.Range(0.0f, 1.0f);
        return val > 0.7f;
    }
    
}