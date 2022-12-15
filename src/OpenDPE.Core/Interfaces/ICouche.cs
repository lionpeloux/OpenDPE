using OpenDPE.Core.Interfaces;
using OpenDPE.Core.Model.Construction;

namespace OpenDPE.Core.Interfaces
{
    interface ICouche
    {
        public double Epaisseur { get; }
        public Materiau Materiau { get; }
        public double R { get; }
        public double U { get; }

    }
}