using UnityEngine;

namespace HW_Patterns
{
    public class СollapsarFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Collapsar>("Enemy/Collapsar "));
        
            enemy.DependencyInjectHealth(hp);
        
            return enemy;
        }
    }
}