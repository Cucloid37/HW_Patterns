using System;

namespace HW_Patterns
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChang;

        void GetAxis();
    }
}