using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ApartmentsManager.Domain.Entities
{
    public class Apartment : Entity
    {
        private readonly IList<Resident> _residents;

        public Apartment() { }

        public Apartment(Condominium condominium, int number, string block, string user)
        {
            Condominium = condominium;
            // CondominiumId = condominium.Id;
            Number = number;
            Block = block;
            User = user;
            Active = true;
            _residents = new List<Resident>();

            Created = DateTime.Now;
        }

        [JsonIgnore]
        public Condominium Condominium { get; private set; }
        public int Number { get; private set; }
        public string Block { get; private set; }
        public string User { get; private set; }
        public bool Active { get; private set; }
        public ICollection<Resident> Residents { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }

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
                Updated = DateTime.Now;
            }
        }

        public void RemoveResident(Resident resident)
        {
            _residents.Remove(resident);
            Updated = DateTime.Now;
        }
    }
}