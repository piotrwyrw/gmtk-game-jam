using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator {
    private float orgY;
    private float _lastX;
    private float orgX;

    // ---- Generator Settings ----
    private const float overlapFlux = 2.0f;

    private float minVerticalDelta = 0.5f;
    private float verticalDeltaFlux = 1.5f;

    private float gradualIncrement = 0.5f;

    private float deathRegionSizeX = 1.0f;

    private GameObject _prefab;
    private GameObject _deathBlock;
    private GameObject _player;
    private PhysicsMaterial2D _material2D;

    private List<KeyValuePair<GameObject, DynamicObject>> _platforms;

    private enum PlatformPosition {
        UPPER,
        LOWER
    };

    private PlatformPosition _lastPosition = PlatformPosition.UPPER;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        this.orgX = orgX;
        this.orgY = orgY;
        LoadPrefab();
    }

    public PlatformGenerator() {
        LoadPrefab();
        _lastX = _player.transform.position.x + _prefab.transform.localScale.x - _player.transform.localScale.x;
        orgX = _lastX;
        orgY = _player.transform.position.y + _prefab.transform.localScale.y - 0.5f;
    }

    private void LoadPrefab() {
        _platforms = new List<KeyValuePair<GameObject, DynamicObject>>();
        GameObject obj = Resources.Load("Platform") as GameObject;
        _prefab = obj;
        _player = GameObject.Find("Player");
        _material2D = Resources.Load("Frictionless") as PhysicsMaterial2D;
        minVerticalDelta = _player.transform.localScale.y;
        _deathBlock = Resources.Load("Deathblock") as GameObject;
        CapsuleCollider2D collider = _player.GetComponent<CapsuleCollider2D>();
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
        return _prefab.transform.localScale.x;
    }

    private GameObject Platform(float x, float y) {
        GameObject p1 = GameObject.Instantiate(_prefab);
        p1.name = "Platform[" + x + ";" + y + "]";
        p1.transform.position = new Vector3(x, y, 0.0f);
        DynamicObject dynObj = p1.GetComponent<DynamicObject>();
        dynObj.frozen = true;
        _platforms.Add(new KeyValuePair<GameObject, DynamicObject>(p1, dynObj));
        return p1;
    }

    private float NextY() {
        float y;
        if (_lastPosition == PlatformPosition.UPPER) {
            y = orgY;
        }
        else {
            y = _prefab.transform.localScale.y + Util.Random(minVerticalDelta, verticalDeltaFlux + minVerticalDelta);
            y += gradualIncrement;
        }

        return y;
    }

    public void GenerateNext() {
        float x = _lastX - Util.Random(0.0f, overlapFlux);
        float y = NextY();
        _lastX = x + _prefab.transform.localScale.x;
        Platform(x, y);
        _lastPosition = (_lastPosition == PlatformPosition.UPPER) ? PlatformPosition.LOWER : PlatformPosition.UPPER;
    }

    public void AutomaticPlatformPerformanceOptimization() {
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * aspect;

        foreach (KeyValuePair<GameObject, DynamicObject> kv in _platforms) {
            GameObject obj = kv.Key;
            if (obj.transform.position.x + obj.transform.localScale.x < Camera.main.transform.position.x + orgX) { ;
                GameObject.Destroy(obj);
                _platforms.Remove(kv);
            }
        }
    }
}