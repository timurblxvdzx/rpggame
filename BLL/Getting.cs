using System.Collections.Generic;
using DAL;
using Models;

namespace BLL
{
    public class Getting
    {
        Storage storage = new Storage();
        public List<Armor> Armors { get; set; } = new List<Armor>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Unit> Units { get; set; } = new List<Unit>();

        public Getting()
        {
            Armors.AddRange(storage.Armors);
            Weapons.AddRange(storage.Weapons);
            Units.AddRange(storage.Units);
        }

        public void Create(Unit unit)
        {
            Units.Add(unit);
        }

    }
}