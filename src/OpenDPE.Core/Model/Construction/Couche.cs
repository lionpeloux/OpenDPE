using OpenDPE.Core.Interfaces;

namespace OpenDPE.Core.Model.Construction
{
    public class Couche : ICouche
    {
        public double Epaisseur { get; private set; }

        public double R { get; private set; }

        public double U { get; private set; }

        public Materiau Materiau { get; private set; }
    }
}