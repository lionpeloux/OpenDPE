using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDPE.Core.Interfaces
{
    public interface IMateriau
    {
        public string Nom { get; }
        public double MasseVolumique { get; }
        public double ChaleurMassique { get; }
        public double Conductivite { get; }

        public bool ThermiquementHomogene { get; }

        public double Effusivite { get; }
        public double Diffusivite { get; }
    }
}
