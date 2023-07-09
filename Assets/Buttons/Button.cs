using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Extensions.Buttons {
    public class Button : MonoBehaviour {

        public static Dictionary<string, Button> Registry = new Dictionary<string, Button>();

        [SerializeField] private string guid = Guid.NewGuid().ToString();
        [SerializeField] private List<GameObject> triggers = new();
        [SerializeField] private Color notClickedColor = Color.black;
        [SerializeField] private Color clickedColor = Color.green;
        
        private readonly Dictionary<GameObject, Collider2D> _collider2Ds = new();
        private BoxCollider2D _collider2D;
        private SpriteRenderer _renderer;
        
        
        public Action<string> OnButtonClicked;

        private void Awake() {
            Registry.TryAdd(guid, this);
            
            this._collider2D = this.AddComponent<BoxCollider2D>();
            this._renderer = this.GetComponent<SpriteRenderer>();
            this._renderer.color = notClickedColor;
            
            
            
            
            triggers.ForEach(o => {
                var playerCollider = o.GetComponent<Collider2D>();

                _collider2Ds.Add(o, playerCollider);
            });
        }

        private void Update() {
            foreach (var keyValuePair in _collider2Ds) {
                if (this._collider2D.IsTouching(keyValuePair.Value)) {
                    this._renderer.color = clickedColor;
                    OnButtonClicked?.Invoke(guid);
                }
                else {
                    this._renderer.color = notClickedColor;
                }
            }
        }
    }
}