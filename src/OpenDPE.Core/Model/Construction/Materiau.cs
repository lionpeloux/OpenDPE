using OpenDPE.Core.Interfaces;

namespace OpenDPE.Core.Model.Construction
{
    class Materiau : IMateriau
    {
        public string Nom { get; private set; }
        public double MasseVolumique { get; private set; }
        public double ChaleurMassique { get; private set; }
        public double Conductivite { get; private set; }

        public double Effusivite => Math.Sqrt(Conductivite * (MasseVolumique * ChaleurMassique));
        public double Diffusivite => Conductivite / (MasseVolumique * ChaleurMassique);

        public bool ThermiquementHomogene { get; private set; }

        private Materiau(string nom, double masseVolumique, double chaleurMassique, double conductivite, bool thermiquementHomogene = true)
        {
            Nom = nom;
            MasseVolumique = masseVolumique;
            ChaleurMassique = chaleurMassique;
            Conductivite = conductivite;
            ThermiquementHomogene = thermiquementHomogene;
        }
    }
}