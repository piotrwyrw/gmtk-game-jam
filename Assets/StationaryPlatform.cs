using UnityEngine;

public class StationaryPlatform : Platform {
    public StationaryPlatform(float width, float height, float x, float y) : base(width, height, x, y) { }
    public StationaryPlatform(Vector2 dimensions, Vector2 location) : base(dimensions, location) { }
    
    public override void Update() {
        // Nothing to do here - This is a stationary platform after all
    }
    
}