using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace HW_Patterns
{
    public sealed class StartGame : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Camera _camera;
        private Controllers _controllers;

        private void Start()
        {
            _camera = Camera.main;
            _controllers = new Controllers();
            var initialization = new GameInitialization(_data, _controllers, _camera);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}

