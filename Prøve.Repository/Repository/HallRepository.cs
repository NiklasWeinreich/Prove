using Microsoft.EntityFrameworkCore;
using Prøve.Repository.Database;
using Prøve.Repository.Interfaces;
using Prøve.Repository.Models;

namespace Prøve.Repository.Repository
{
    public class HallRepository : IHallRepository
    {
        public DatabaseContext _context { get; set; }

        public HallRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Hall> readSeatsInHall(int hallId)
        {
            return await _context.Hall.Include(s => s.seats).FirstOrDefaultAsync(x => x.Id == hallId);
            
        }

        public async Task<List<Reserved>> readReservedSeats()
        {
            return await _context.Reserved.Where(s => s.booked == true).ToListAsync();
        }

        public async Task delete(bool choice)
        {
            var seatsToDelete = _context.Seat
            .Where(seat => seat.Id % 2 == (choice ? 0 : 1))
            .ToList();

            _context.Seat.RemoveRange(seatsToDelete);
            
            await _context.SaveChangesAsync();
        }

        public async Task delete(bool choice, int hallId)
        {
            throw new NotImplementedException();

        }

        public Task create(int rowCount, int colCount)          
        {
            
            Hall hall = new Hall();

            hall.Name = "Hall 1";
            hall.seats = new List<Seat>();

            //Tilføjer til databasen
            _context.Hall.Add(hall);
            //Gemmer i databasen
            _context.SaveChanges();

            for (int r = 1; r < rowCount + 1; r++)
            {

                for (int c = 1; c < colCount + 1; c++)
                {

                    Seat seat = new Seat();

                    seat.SeatRow = r;
                    seat.SeatCol = c;
                    _context.Seat.Add(seat);
                    hall.seats.Add(seat);

                }

            }

            _context.SaveChanges();

            return Task.CompletedTask;

        }

        public void createReserved(Hall hall)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reserved>> reserved(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
