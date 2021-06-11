using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Models;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : IBaseRepository<Asset>
    {
        private readonly DataContext _context;

        public AssetRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Asset asset)
        {
            //TODO: create validator to check data before save on database
            _context.Assets.Add(asset);
            //_context.SaveChangesAsync();//TODO: replace for unity of work
        }

        public async Task Edit(int id, Asset asset)
        {
            var editAsset = await _context.Assets.FindAsync(id);

            if (editAsset == null)
                throw new Exception();//TODO: implements custom message error.

            //TODO: create DTOS
            editAsset.AssetName = asset.AssetName;
            editAsset.Department = asset.Department;
            editAsset.CountryOfDepartment = asset.CountryOfDepartment;
            editAsset.EMailAdressOfDepartment = asset.EMailAdressOfDepartment;
            editAsset.PurchaseDate = asset.PurchaseDate;
            editAsset.broken = asset.broken;
            
            _context.Assets.Add(editAsset);
            //await _context.SaveChangesAsync();//TODO: replace for unity of work
        }

        public async Task<IQueryable<Asset>> FindAll()
        {
            //var assets = await _context.Assets.ToListAsync();
            return (IQueryable<Asset>) await _context.Assets.ToListAsync();
            //return (IQueryable<Asset>)assets;
        }

        public async Task<Asset> FindById(int id)
        {
            var getAsset = await _context.Assets.FindAsync(id);

            if (getAsset == null)
                throw new Exception();//TODO: implements custom message error.

            return getAsset;
        }

        public async Task Remove(int id)
        {
            var removeAsset = await _context.Assets.FindAsync(id);

            if (removeAsset == null)
                throw new Exception();//TODO: implements custom message error.

            _context.Assets.Remove(removeAsset);
            //await _context.SaveChangesAsync();//TODO: replace for unity of work
        }
    }
}
