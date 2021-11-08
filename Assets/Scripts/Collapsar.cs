using UnityEngine;

namespace HW_Patterns
{
    public sealed class Collapsar : Enemy, ICloseAttack
    {
        
        public void SetScale(Vector3 scale)
        {
            transform.localScale = scale;
        }

        public void CloseAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}