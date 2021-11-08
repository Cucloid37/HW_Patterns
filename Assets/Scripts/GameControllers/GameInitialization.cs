using UnityEngine;

namespace HW_Patterns
{
    public sealed class GameInitialization
    {
        public GameInitialization(Data data, Controllers controllers, Camera camera)
        {
            IPlayerFactory playerFactory = new PlayerFactory();
            var inputInitialization = new InputInitialization();
            var playerView = playerFactory.CreateView();
            var bulletPool = new BulletPool(10);
            var player = new PlayerControl(camera, playerView, bulletPool);
            playerView.AddPlayerControl(player);
            controllers.Add(inputInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(player);



            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = factory;

            Enemy.Factory.Create(new Health(100.0f, 100.0f));
        }
    }
}