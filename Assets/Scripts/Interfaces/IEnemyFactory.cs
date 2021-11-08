namespace HW_Patterns
{
    public interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}