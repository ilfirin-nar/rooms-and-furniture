namespace RoomsAndFurniture.Web
{
    public interface IDatabaseInitializer
    {
        void Initialize();

        void Recreate();
    }
}