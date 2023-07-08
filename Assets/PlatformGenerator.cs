using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator {
    private float _lastX;
    private float _lastY;

    // ---- Generator Settings ----
    private const float _minXDelta = 2.0f; // Minimum spacing between platforms
    private const float _deltaXFluctuations = 0.5f; // Randomness to _minXDelta

    private const float _maxXMovement = 3.0f; // Maximum amount a platform can move around in the X axis
    private const float _minXMovement = 2.0f; // Min. movement

    private const float _maxYMovement = 4.0f; // Maximum amount a platform can move around in the Y axis
    private const float _minYMovement = 2.0f; // Min. movement

    private List<GameObject> _platforms;
    private GameObject prefab;

    public PlatformGenerator(float orgX, float orgY) {
        _lastX = orgX;
        _lastY = orgY;
        _platforms = new List<GameObject>();
        LoadPrefab();
    }

    private void LoadPrefab() {
        GameObject obj = Resources.Load("Platform") as GameObject;
        prefab = obj;
    }

    public PlatformGenerator() {
        GameObject obj = GameObject.Find("Player");
        LoadPrefab();
        _lastX = obj.transform.position.x + prefab.transform.localScale.y - 0.5f;
        _lastY = obj.transform.position.y - prefab.transform.localScale.y - _maxYMovement;
        _platforms = new List<GameObject>();
    }

    public void GenerateNext() {
        float startX, startY;

        startX = _lastX;
        startY = _lastY;

        // Is the platform stationary?
        bool stat = Util.Random();

        float endX, endY;

        if (stat) {
            endX = startX;
            endY = startY;
        }
        else {
            endX = startX + Util.Random(_minXMovement, _maxXMovement);
            endY = startY + Util.Random(_minYMovement, _maxYMovement);
        }

        GameObject obj = Resources.Load("Platform") as GameObject;
        GameObject platform = GameObject.Instantiate(obj);
        platform.name = "Dyn. Platform #" + _platforms.Count;
        _lastX = endX + platform.transform.localScale.x + _minXDelta + Util.Random(0.0f, _deltaXFluctuations);
        DynamicObject dynObj = platform.GetComponent<DynamicObject>();
        dynObj.startXPos = startX;
        dynObj.startYPos = startY;
        dynObj.m_initialPosition = new Vector3(startX, startY);
        dynObj.endXPos = endX;
        dynObj.endYPos = endY;

        _platforms.Add(obj);
    }
}