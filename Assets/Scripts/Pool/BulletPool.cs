using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HW_Patterns
{
    public sealed class BulletPool
    {
        private readonly Dictionary<string, HashSet<Bullet>> _bulletPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        
        public BulletPool(int capacityPool)
        {
            _bulletPool = new Dictionary<string, HashSet<Bullet>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_BULLET).transform;
            }
        }
        
        public Bullet GetBullet(string type)
        {
            Bullet result;
            switch (type)
            {
                case NameManager.BULLET:
                    result = GetBullet((HashSet<Bullet>) GetListBullet(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }
        
        private HashSet<Bullet> GetListBullet(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<Bullet>();
        }

        private Bullet GetBullet(HashSet<Bullet> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null )
            {
                var laser = Resources.Load<Bullet>("Bullet/Bullet");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                } GetBullet(bullets);
            }
            
            return bullet;
        }
        
        public void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}