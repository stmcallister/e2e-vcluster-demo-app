namespace Backend.Models;

public static class BurgerPlaceDataStore
{
    static BurgerPlaceDataStore()
    {
        Database = new List<BurgerPlace>();
    }

    public static List<BurgerPlace> Database { get; }

}
