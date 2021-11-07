using UnityEngine;

namespace HW_Patterns
{
    public class InputInitialization : IInitialization
    {
        private IUserInputProxy _userInputLeft;
        private IUserInputProxy _userInputRight;
        private IUserInputProxy _userInputHorizontal;
        private IUserInputProxy _userInputVertical;

        /// <summary>
        /// Инициализируем мышь под устройство
        /// </summary>
        public void Initialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _userInputLeft = new MobileInput();     // На данный момент ничего не передаёт
                _userInputRight = new MobileInput();
                _userInputHorizontal = new MobileInput();
                _userInputVertical = new MobileInput();   //
                return;
            }

            _userInputLeft = new PCUserInputLeft();
            _userInputRight = new PCUserInputRight();
            _userInputHorizontal = new PCUserInputHorizontal();
            _userInputVertical = new PCUserInputVertical();

        }
        
        
        /// <summary>
        /// Передаем две мыши в GetInput
        /// </summary>
        /// <returns></returns>
        public (IUserInputProxy InputLeft, IUserInputProxy IputRight, IUserInputProxy InputHorizonta, IUserInputProxy InputVertical) GetInput()
        {
            (IUserInputProxy userInputLeft, IUserInputProxy userInputRight, IUserInputProxy InputHorizonta, IUserInputProxy InputVertical) 
                result = (_userInputLeft, _userInputRight, _userInputHorizontal, _userInputVertical);
            return result;
        }
    }
}