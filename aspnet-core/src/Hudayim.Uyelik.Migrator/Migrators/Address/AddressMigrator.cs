using EFCore.BulkExtensions;
using Hudayim.Uyelik.Entities;
using Hudayim.Uyelik.EntityFrameworkCore;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis;
using Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik;
using Hudayim.Uyelik.Migrator.Migrators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Migrator
{
	public class AddressMigrator : MigratorBase
	{
		public AddressMigrator(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log) : base(_dbContextIB, _dbContextUyelik, _dbContextUyelik2, log)
		{

		}

		public override void Migrate()
		{
			Log.Write("Address Start");
			var sourceCountries = dbContextIB.Ulkeler.ToList();
			var sourceCities = dbContextIB.Iller.ToList();
			var sourceCounties = dbContextIB.Ilceler.ToList();
			var sourceDistricts = dbContextIB.Mahalleler.ToList();

			#region Country
			if (sourceCountries != null && sourceCountries.Count > 0)
			{
				Log.Write("Country Start");
				Log.Write($"Total {sourceCountries.Count} countries");
				var newCountryList = new List<Ulke>();

				int countryCount = 1;
				foreach (var item in sourceCountries)
				{
					Ulke ulke = new Ulke();

					ulke.Ad = item.Ad;
					ulke.SiraNo = countryCount;
					ulke.CreationTime = DateTime.Now;
					ulke.IsDeleted = false;
					ulke.SourceId = item.Id;

					countryCount++;

					newCountryList.Add(ulke);
				}

				if (newCountryList != null)
					dbContextUyelik.BulkInsert(newCountryList);

			}
			#endregion

			#region City
			//Cities
			if (sourceCities != null && sourceCities.Count > 0)
			{
				Log.Write("City Start");

				var countries = dbContextUyelik.Ulkeler.Where(x => x.SourceId != null).ToList();
				var cities = dbContextUyelik.Iller.Where(x => x.SourceId != null).ToList();
				var newCityList = new List<Il>();

				Log.Write($"Total {sourceCities.Count} cities");

				int cityCount = 1;
				//ver igruplanacağı için null kayıt olmaması önemli.
				foreach (var item in sourceCities.GroupBy(g => g.UlkeId))
				{
					var country = countries.FirstOrDefault(x => x.SourceId == (int)item.Key);
					if (country != null)
					{
						foreach (var sCity in sourceCities.Where(x => x.UlkeId == item.Key))
						{
							Il il = new Il();

							il.Ad = sCity.Ad;
							il.SiraNo = cityCount;
							il.PlakaKodu = sCity.PlakaKodu;
							il.UlkeId = country.Id;
							il.IsDeleted = false;
							il.CreationTime = DateTime.Now;
							il.SourceId = sCity.Id;

							cityCount++;
							newCityList.Add(il);
						}
					}
				}
				if (newCityList != null)
					dbContextUyelik.BulkInsert(newCityList);
			}
			#endregion

			#region County
			//Counties
			if (sourceCounties != null && sourceCounties.Count > 0)
			{
				Log.Write("Country Start");
				var cities = dbContextUyelik.Iller.Where(x => x.SourceId != null).ToList();
				var counties = dbContextUyelik.Ilceler.Where(x => x.SourceId != null).ToList();
				var newCountyList = new List<Ilce>();

				Log.Write($"Total {sourceCounties.Count} counties");
				int countyCount = 1;
				foreach (var item in sourceCounties.GroupBy(g => g.IlId))
				{
					var city = cities.FirstOrDefault(x => x.SourceId == (int)item.Key);
					if (city != null)
					{
						foreach (var sCounty in sourceCounties.Where(x => x.IlId == item.Key))
						{
							Ilce ilce = new Ilce();

							ilce.Ad = sCounty.Ad;
							ilce.IlId = city.Id;
							ilce.IsDeleted = false;
							ilce.CreationTime = DateTime.Now;
							ilce.SiraNo = countyCount;
							ilce.SourceId = sCounty.Id;

							countyCount++;

							newCountyList.Add(ilce);
						}
					}
				}
				if (newCountyList != null)
					dbContextUyelik.BulkInsert(newCountyList);
			}
			#endregion

			#region District
			//District
			if (sourceDistricts != null && sourceDistricts.Count > 0)
			{
				Log.Write("District Start");
				var counties = dbContextUyelik.Ilceler.Where(x => x.SourceId != null).ToList();
				var districts = dbContextUyelik.Mahalleler.Where(x => x.SourceId != null).ToList();
				var newCDistrictList = new List<Mahalle>();

				Log.Write($"Total {sourceDistricts.Count} districts");
				int districtCount = 1;
				foreach (var item in sourceDistricts.GroupBy(g => g.IlceId))
				{
					var county = counties.FirstOrDefault(x => x.SourceId == (int)item.Key);
					if (county != null)
					{
						foreach (var sDistrict in sourceDistricts.Where(x => x.IlceId == item.Key))
						{
							Mahalle mahalle = new Mahalle();

							mahalle.Ad = sDistrict.Ad;
							mahalle.IlceId = county.Id;
							mahalle.IsDeleted = false;
							mahalle.CreationTime = DateTime.Now;
							mahalle.SiraNo = districtCount;
							mahalle.SourceId = sDistrict.Id;

							districtCount++;

							newCDistrictList.Add(mahalle);
						}
					}
				}
				if (newCDistrictList != null)
					dbContextUyelik.BulkInsert(newCDistrictList);

			}
			#endregion
		}
	}
}