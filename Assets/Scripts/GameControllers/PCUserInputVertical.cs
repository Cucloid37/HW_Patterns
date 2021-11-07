using System;
using UnityEngine;

namespace HW_Patterns
{
    public class PCUserInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChang = delegate(float f) {  };
        public void GetAxis()
        {
            AxisOnChang.Invoke(Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}