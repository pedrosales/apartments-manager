using System.Collections.Generic;
using System.Linq;

namespace ApartmentsManager.Domain.Entities
{
    public class Apartment : Entity
    {
        private readonly IList<Resident> _residents;

        public Apartment(int number, int block)
        {
            Number = number;
            Block = block;
            _residents = new List<Resident>();
        }

        public int Number { get; private set; }
        public int Block { get; private set; }
        public IReadOnlyCollection<Resident> Residents => _residents.ToArray();

        public void AddResident(Resident resident)
        {
            if (resident != null)
            {
                foreach (var res in _residents)
                {
                    if (res.ToString().Equals(resident.ToString()))
                    {
                        AddNotification("Resident", $"Morador {resident.ToString()} já existe");
                        return;
                    }
                }

                _residents.Add(resident);
            }
        }

        public void RemoveResident(Resident resident)
        {
            _residents.Remove(resident);
        }
    }
}