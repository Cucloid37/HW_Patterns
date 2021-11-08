using System;
using UnityEngine;

namespace HW_Patterns
{
    public sealed class PlayerView : MonoBehaviour
    {
        private PlayerControl _playerControl;
        private bool _onCollision;
        public bool OnCollision => _onCollision;
        
        public PlayerControl PlayerControl => _playerControl;

        public void AddPlayerControl(PlayerControl player)
        {
            _playerControl = player;
        }
        
        public void Die()
        {
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _onCollision = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _onCollision = false;
        }
        
    }
}