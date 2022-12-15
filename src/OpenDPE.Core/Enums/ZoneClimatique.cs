namespace OpenDPE.Core
{
    public enum ZoneClimatique
    {
        // Aucune = 0,
        H1a = 1 << 0,
        H1b = 1 << 1,
        H1c = 1 << 2,
        // H1 = H1a | H1b | H1c,
        H2a = 1 << 3,
        H2b = 1 << 4,
        H2c = 1 << 5,
        H2d = 1 << 6,
        // H2 = H2a | H2b | H2c,
        H3 = 1 << 7,
    };
}