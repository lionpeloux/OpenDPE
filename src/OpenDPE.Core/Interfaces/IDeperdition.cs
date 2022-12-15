namespace OpenDPE.Core.Interfaces
{
    public interface IDeperdition
    {
        /// <summary>
        /// Coefficeint de déperdition par transmission
        /// </summary>
        double DPK { get; }
    }

    public interface IDeperditionSurfacique : IDeperdition
    {
        /// <summary>
        /// Surface de l'élément déperditif.
        /// </summary>
        double Surface { get; }

        /// <summary>
        /// Coefficient de transmission surfacique U en W/(m2.K).
        /// </summary>
        double U { get; }

        /// <summary>
        /// Résistance thermique R, en (m2.K)/W.
        /// </summary>
        double R => 1 / U;
    }

    public interface IDeperditionLineique : IDeperdition
    {

        /// <summary>
        /// Longueur de l'élément déperditif.
        /// </summary>
        double Longueur { get; }

        /// <summary>
        /// Coefficient de transmission linéique Ψ en W/(m.K).
        /// </summary>
        double Psi { get; }

    }

    public interface IDeperditionPonctuelle : IDeperdition
    {

        /// <summary>
        /// Coefficient de transmission ponctuel χ en W/K.
        /// </summary>
        double Chi { get; }

    }
}
