
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prøve.Repository.Interfaces
{
    public interface IHallRepository
    {
        public Task<Hall> readSeatsInHall(int hallId);
        public Task<List<Reserved>> readReservedSeats();
        public Task delete(bool choice);
        public Task delete(bool choice, int hallId); //mere advaceret
        public Task create(int rowCount, int colCount);
        public void createReserved(Hall hall); //No task here.. its easier without
        public Task<List<Reserved>> reserved(DateTime date);
    }
}
