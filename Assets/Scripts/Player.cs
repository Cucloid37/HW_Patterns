using UnityEngine;

namespace HW_Patterns
{
    public class Player
    {
        private PlayerView _view;
        public float Speed => 5;

        public float Acceleration => 2;

        [SerializeField] private float _hp;
        private Camera _camera;
        

        public Player(Camera camera, PlayerView view)
        {
            _camera = camera;
            _view = view;

        }

        public void GetDamage()
        {
            if (_hp <= 0)
            {
                _view.Die();
            }
            else
            {
                _hp--;
            }
        }
        
    }
}