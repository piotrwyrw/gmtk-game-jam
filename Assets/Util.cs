
using Unity.Mathematics;

public class Util {
    public static float Random(float min, float max) {
        Random rand = new Random();
        return rand.NextFloat(min, max);
    }
    
    public static bool Random() {
        Random rand = new Random();
        return rand.NextBool();
    }
    
}