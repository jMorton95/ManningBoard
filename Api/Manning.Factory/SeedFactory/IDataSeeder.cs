namespace Manning.Factory.SeedFactory;

public interface IDataSeeder
{
    void RunDataSeed();
    void SeedLine();

    void SeedOperators();

    void SeedTraining();
}