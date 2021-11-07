using System.Collections.Generic;

namespace HW_Patterns
{
    public sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup
    {
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeController;
        private readonly List<ILateExecute> _lateExecutes;
        private readonly List<ICleanup> _cleanups;

        private const int CapacityList = 8;
        
        public Controllers()
        {
            _initializeControllers = new List<IInitialization>(CapacityList);
            _executeController = new List<IExecute>(CapacityList);
            _lateExecutes = new List<ILateExecute>(CapacityList);
            _cleanups = new List<ICleanup>(CapacityList);
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute execute)
            {
                _executeController.Add(execute);
            }

            if (controller is ILateExecute lateExecute)
            {
                _lateExecutes.Add(lateExecute);
            }

            if (controller is ICleanup cleanup)
            {
                _cleanups.Add(cleanup);
            }

            return this;
        }
        
        public void Initialization()
        {
            for (int index = 0; index < _initializeControllers.Count; index++)
            {
                _initializeControllers[index].Initialization();
            }
        }
        
        public void Execute(float deltaTime)
        {
            for (int index = 0; index < _executeController.Count; index++)
            {
                _executeController[index].Execute(deltaTime);
            }
        }


        public void LateExecute(float deltaTime)
        {
            for (int index = 0; index < _lateExecutes.Count; index++)
            {
                _lateExecutes[index].LateExecute(deltaTime);
            }
        }
        
        public void Cleanup()
        {
            for (int index = 0; index < _cleanups.Count; index++)
            {
                _cleanups[index].Cleanup();
            }
        }
    }
}