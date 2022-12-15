namespace OpenDPE.Core
{
    public partial class Departement : IEquatable<Departement>
    {
        
        public string Nom { get; private set; }
        public string Code { get; private set; }
        public ZoneClimatique ZoneClimatique { get; private set; }

        public Departement(string nom, string code, ZoneClimatique zoneClimatique)
        {
            Nom = nom;
            Code = code;
            ZoneClimatique = zoneClimatique;
        }

        public static Departement ParNom(NomDepartement nom)
        {
            var index = (int)nom;
            return _table[index];
        }
        public static Departement ParCode(string code)
        {
            string search;
            int numero;

            if (Int32.TryParse(code, out numero))
            {
                search = numero.ToString("00"); // pour les codes de 1 à 9 au format 01 à 09
            }
            else
            {
                search = code;
            }
            
            for (int i = 0; i < _table.Length; i++)
            {
                if (_table[i].Code == search) return _table[i];
            }
            throw new ArgumentException(string.Format("{0} n'est pas un code de département valide", code));
        }

        public override string ToString()
        {
            return string.Format("{0} - {2} ({1})", this.Code, this.ZoneClimatique, this.Nom);
        }
        public bool Equals(Departement? other)
        {
            if (other == null) return false;
            return Nom == other.Nom && Code == other.Code && ZoneClimatique == other.ZoneClimatique;
        }
    }
}
