namespace BoatRentalSystem.Services.BoatServices
{
    public interface IBoatService
    {
        Task<List<Boat>> GetAllBoats();
        Task<Boat?> GetSingleBoat(int id);
        Task<List<Boat>> AddBoat(Boat boat);
        Task<List<Boat>?> UpdateBoat(int id, Boat request);
        Task<List<Boat>?> DeleteBoat(int id);
    }
}
