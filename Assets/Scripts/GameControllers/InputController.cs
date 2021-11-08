namespace HW_Patterns
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _mouseRight;
        private readonly IUserInputProxy _mouseLeft;
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;


        public InputController((IUserInputProxy Right, IUserInputProxy Left, IUserInputProxy Horizontal, IUserInputProxy Vertical) input)
        {
            _mouseRight = input.Right;
            _mouseLeft = input.Left;
            _horizontal = input.Horizontal;
            _vertical = input.Vertical;
        }

        public void Execute(float deltaTime)
        {
            _mouseRight.GetAxis();
            _mouseLeft.GetAxis();
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}