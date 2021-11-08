using UnityEngine;

namespace HW_Patterns
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private Transform _transform;
        
        public Transform CreateOrGet()
        {
            if (_transform != null)
            {
                return _transform;
            }
            
            return _transform = Object.Instantiate(Resources.Load<PlayerView>("Player/PlayerView")).transform;
        
        }

        public PlayerView CreateView()
        {
            if (_transform != null)
            {
                return _transform.GetComponent<PlayerView>();
            }

            return CreateOrGet().GetComponent<PlayerView>();
        }
    }
}