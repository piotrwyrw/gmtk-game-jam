using UnityEngine;

public class PlatformGenerator {
    private float orgY;
    private float _lastX;

    // ---- Generator Settings ----
    private const float overlapFlux = 2.0f;

    private float minVerticalDelta = 0.5f;
    private float verticalDeltaFlux = 1.5f;

    private float gradualIncrement = 0.5f;

    private GameObject prefab;
    private GameObject player;
    private PhysicsMaterial2D _material2D;

    private enum PlatformPosition {
        UPPER,
        LOWER
    };

    private PlatformPosition _lastPosition = PlatformPosition.UPPER;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        this.orgY = orgY;
        LoadPrefab();
    }

    public PlatformGenerator() {
        LoadPrefab();
        _lastX = player.transform.position.x + prefab.transform.localScale.y - 0.5f;
        orgY = player.transform.position.y + prefab.transform.localScale.y - 0.5f;
    }

    private void LoadPrefab() {
        GameObject obj = Resources.Load("Platform") as GameObject;
        prefab = obj;
        player = GameObject.Find("Player");
        _material2D = Resources.Load("Frictionless") as PhysicsMaterial2D;
        minVerticalDelta = player.transform.localScale.y;
        CapsuleCollider2D collider = player.GetComponent<CapsuleCollider2D>();
        if (collider == null) {
            Debug.LogWarning("The player object has no BoxCollider2D");
            return;
        }

        collider.sharedMaterial = _material2D;
    }

    private float RandomVerticalDelta() {
        return Util.Random(minVerticalDelta, minVerticalDelta + verticalDeltaFlux);
    }

    private float MaxSpacing() {
        return prefab.transform.localScale.x;
    }

    private GameObject Platform(float x, float y) {
        GameObject p1 = GameObject.Instantiate(prefab);
        p1.transform.position = new Vector3(x, y, 0.0f);
        DynamicObject dynObj = p1.GetComponent<DynamicObject>();
        dynObj.frozen = true;
        return p1;
    }

    private float NextY() {
        float y;
        if (_lastPosition == PlatformPosition.UPPER) {
            y = orgY;
            orgY += gradualIncrement;
        }  else {
            y = prefab.transform.localScale.y + Util.Random(minVerticalDelta, verticalDeltaFlux + minVerticalDelta);
            y += gradualIncrement;
        }
        return y;
    }

    public void GenerateNext() {
        float x = _lastX - Util.Random(0.0f, overlapFlux);
        float y = NextY();
        _lastX = x + prefab.transform.localScale.x;
        Platform(x, y);
        _lastPosition = (_lastPosition == PlatformPosition.UPPER) ? PlatformPosition.LOWER : PlatformPosition.UPPER;
    }
}