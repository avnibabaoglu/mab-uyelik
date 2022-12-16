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
	public class UniversityMigrator : MigratorBase
	{
		public UniversityMigrator(IBDBContext _dbContextIB, UyelikDbContext _dbContextUyelik, UyelikDBContext _dbContextUyelik2, Log log) : base(_dbContextIB, _dbContextUyelik, _dbContextUyelik2, log)
		{

		}

		public override void Migrate()
		{
			Log.Write("University Start");
			var sourceUniversiteler = dbContextUyelik2.UniversitelerListesi.ToList();
			var sourceFakulteler = dbContextUyelik2.FakultelerListesi.ToList();
			var sourceBolumler = dbContextUyelik2.BolumlerListesi.ToList();

			#region Üniversite
			if (sourceUniversiteler != null && sourceUniversiteler.Count > 0)
			{
				Log.Write("University Start");
				Log.Write($"Total {sourceUniversiteler.Count} University");
				var newUniversityList = new List<Universite>();

				int universiteCount = 1;
				foreach (var item in sourceUniversiteler)
				{
					Universite universite = new Universite();

					universite.Ad = item.Ad;
					universite.AktifMi = true;
					universite.SiraNo = universiteCount;
					universite.CreationTime = DateTime.Now;
					universite.IsDeleted = false;
					universite.SourceId = item.Id;

					universiteCount++;

					newUniversityList.Add(universite);
				}

				if (newUniversityList != null)
					dbContextUyelik.BulkInsert(newUniversityList);

			}
			#endregion

			#region Fakulte
			//Cities
			if (sourceFakulteler != null && sourceFakulteler.Count > 0)
			{
				Log.Write("Fakulte Start");

				var universiteler = dbContextUyelik.Universiteler.Where(x => x.SourceId != null).ToList();
				var fakulteler = dbContextUyelik.UniversiteFakulteler.Where(x => x.SourceId != null).ToList();
				var newFakulteList = new List<Fakulte>();

				Log.Write($"Total {sourceFakulteler.Count} fakulte");

				int fakulteCount = 1;
				foreach (var item in sourceFakulteler.GroupBy(g => g.UniversiteId))
				{
					var universite = universiteler.FirstOrDefault(x => x.SourceId == (int)item.Key);
					if (universite != null)
					{
						foreach (var sFakulte in sourceFakulteler.Where(x => x.UniversiteId == item.Key))
						{
							Fakulte fakulte = new Fakulte();

							fakulte.Ad = sFakulte.Ad;
							fakulte.SiraNo = fakulteCount;
							fakulte.AktifMi = true;
							fakulte.UniversiteId = universite.Id;
							fakulte.IsDeleted = false;
							fakulte.CreationTime = DateTime.Now;
							fakulte.SourceId = sFakulte.Id;

							fakulteCount++;
							newFakulteList.Add(fakulte);
						}
					}
				}
				if (newFakulteList != null)
					dbContextUyelik.BulkInsert(newFakulteList);
			}
			#endregion

			#region Bolum
			if (sourceBolumler != null && sourceBolumler.Count > 0)
			{
				Log.Write("Bolum Start");			  
				var fakulteler = dbContextUyelik.UniversiteFakulteler.Where(x => x.SourceId != null).ToList();
				var bolumler = dbContextUyelik.UniversiteBolumler.Where(x => x.SourceId != null).ToList();
				var newBolumList = new List<Bolum>();

				Log.Write($"Total {sourceBolumler.Count} counties");
				int bolumCount = 1;
				foreach (var item in sourceBolumler.GroupBy(g => g.FakulteId))
				{
					var fakulte = fakulteler.FirstOrDefault(x => x.SourceId == (int)item.Key);
					if (fakulte != null)
					{
						foreach (var sBolum in sourceBolumler.Where(x => x.FakulteId == item.Key))
						{
							Bolum bolum = new Bolum();

							bolum.Ad = sBolum.Ad;
							bolum.FakulteId = fakulte.Id;
							bolum.UniversiteId = fakulte.UniversiteId;
							bolum.AktifMi = true;
							bolum.IsDeleted = false;
							bolum.CreationTime = DateTime.Now;
							bolum.SiraNo = bolumCount;
							bolum.SourceId = sBolum.Id;

							bolumCount++;

							newBolumList.Add(bolum);
						}
					}
				}
				if (newBolumList != null)
					dbContextUyelik.BulkInsert(newBolumList);
			}
			#endregion
		}
	}
}