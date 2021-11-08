using UnityEngine;

namespace HW_Patterns
{
    public class PlayerControl : Player, IExecute
    {
        // #TODO получать Input через интерфейс IUserInputProxy
        
        private PlayerView _view;
        private readonly Camera _camera;
        private Ship _ship;
        private IMove _moveTransform;
        private IRotation _rotation;
        private BulletPool _bulletPool;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        
        public PlayerControl(Camera camera, PlayerView view, BulletPool bulletPool) : base(camera, view)
        {
            _camera = camera;
            _view = view;
            _moveTransform = new AccelerationMove(_view.transform, Speed, Acceleration);;
            _rotation = new RotationShip(_view.transform);
            _ship = new Ship(_moveTransform, _rotation);
            _bulletPool = bulletPool;
        }
        
        public void Execute(float deltaTime)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_view.transform.position);
            _rotation.Rotation(direction);

            _moveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.AddAcceleration();
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }

            // #TODO Pool Object for bullet
            
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = _bulletPool.GetBullet(NameManager.BULLET);
                temAmmunition.transform.position = _barrel.position;
                temAmmunition.transform.rotation = _barrel.rotation;
                
                temAmmunition.GetComponent<Bullet>().Fire(_barrel.up, _force);
                _bulletPool.ReturnToPool(temAmmunition.transform);
            }
        }
    }
}