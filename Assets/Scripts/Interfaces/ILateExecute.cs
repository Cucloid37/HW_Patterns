namespace HW_Patterns
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}