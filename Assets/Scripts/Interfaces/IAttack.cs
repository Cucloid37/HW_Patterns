using System;

namespace HW_Patterns
{
    public interface IAttack
    {
        event Action<PlayerView> action;
        void Attack(PlayerView player);
    }

    public interface IDistanceAttack : IAttack
    {
        void DistanceAttack();
    }

    public interface ICloseAttack : IAttack
    {
        void CloseAttack();
    }
}