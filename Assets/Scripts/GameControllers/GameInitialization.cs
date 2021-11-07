namespace HW_Patterns
{
    public sealed class GameInitialization
    {
        public GameInitialization(Data data, Controllers controllers)
        {

            var inputInitialization = new InputInitialization();
            controllers.Add(inputInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));

        }
    }
}