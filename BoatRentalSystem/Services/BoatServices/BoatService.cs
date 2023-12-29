namespace BoatRentalSystem.Services.BoatServices
{
    public class BoatService : IBoatService
    {
        private static List<Boat> boats = new List<Boat>
        {
            new Boat { Id = 1, Name = "hero"}
            , new Boat { Id = 2, Name = "shark"}

        };
        private readonly DataContext _dataContext;
        public BoatService(DataContext context) 
        {
            _dataContext = context;
        }
        public async Task<List<Boat>> AddBoat(Boat boat)
        {
            _dataContext.Boats.Add(boat);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Boats.ToListAsync();
        }

        public async Task<List<Boat>?> DeleteBoat(int id)
        {
            var boat = await _dataContext.Boats.FindAsync(id);
            if (boat == null)
                return null;

            _dataContext.Boats.Remove(boat);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Boats.ToListAsync();
        }

        public async Task<List<Boat>> GetAllBoats()
        {
            var boats = await _dataContext.Boats.ToListAsync();
            return boats;
        }

        public async Task<Boat?> GetSingleBoat(int id)
        {
            var boat = await _dataContext.Boats.FindAsync(id);
            if (boat == null)
                return null;
            return boat;
        }

        public async Task<List<Boat>?> UpdateBoat(int id, Boat request)
        {
            var boat = await _dataContext.Boats.FindAsync(id);
            if (boat == null)
                return null;
            boat.Name = request.Name;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Boats.ToListAsync();
        }
    }
}
