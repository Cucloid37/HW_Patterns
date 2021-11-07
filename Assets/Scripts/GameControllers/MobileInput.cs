using System;

namespace HW_Patterns
{
    public class MobileInput : IUserInputProxy
    {
        public event Action<float> AxisOnChang;
        public void GetAxis()
        {
            // Что-то тут передаёт MobileInput
        }
    }
}