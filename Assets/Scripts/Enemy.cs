using System;
using TMPro;
using UnityEngine;

namespace HW_Patterns
{
    public delegate void AttackDelegate(PlayerView player);
    
    public abstract class Enemy : MonoBehaviour, IAttack
    {
        public static IEnemyFactory Factory;
        private Transform _rootPool;
        private Health _health;

        public event Action<PlayerView> action = delegate(PlayerView view) { };
        
        public bool ICanAttack { get; set; }

        private void Start()
        {
            action += Attack;
        }

        public virtual void Attack(PlayerView player)
        {
            player.PlayerControl.GetDamage();
        }

        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }
        
        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }


        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
        
            enemy.Health = hp;
        
            return enemy;
        }

        public static Collapsar CreateCollapsarEnemy(Health hp, Vector3 scale)
        {
            var enemy = Instantiate(Resources.Load<Collapsar>("Enemy/Collapsar"));
        
            enemy.Health = hp;
            enemy.SetScale(scale);
        
            return enemy;
        }
        
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                action?.Invoke(other.gameObject.GetComponent<PlayerView>());
            }
        }
    }
}