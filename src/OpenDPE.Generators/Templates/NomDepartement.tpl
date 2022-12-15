namespace OpenDPE.Core
{
	public enum NomDepartement
	{
		{{~ for departement in departements ~}}
		{{ departement.enum }},
		{{~ end ~}}
	}
}
