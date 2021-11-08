using UnityEngine;

namespace HW_Patterns
{
    public interface IPlayerFactory
    {
        Transform CreateOrGet();

        PlayerView CreateView();
    }
}