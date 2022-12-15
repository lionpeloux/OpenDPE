namespace OpenDPE.Core
{
	partial class Departement
	{
		#region DEPARTEMENTS
		
		private readonly static Departement[] _table = new Departement[]
		{
			{{~ for departement in departements ~}}
			new Departement("{{- departement.nom }}", "{{ departement.code }}", ZoneClimatique.{{ departement.zone_climatique }}),
		{{~ end ~}}
		};

		#endregion
	}
}
