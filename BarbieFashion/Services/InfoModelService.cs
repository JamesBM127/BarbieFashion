using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarbieFashion.Data;
using BarbieFashion.Models;
using BarbieFashion.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BarbieFashion.Services
{
    public class InfoModelService
    {
        private readonly BarbieFashionContext _barbieContext;

        public InfoModelService(BarbieFashionContext barbieContext)
        {
            _barbieContext = barbieContext;
        }

        public async Task<List<InfoModel>> FindAllAsync()
        {
            return await _barbieContext.InfoModels.ToListAsync();
        }

        public async Task<InfoModel> FindByIdAsync(int id)
        {
            return await _barbieContext.InfoModels.Include(obj => obj.Agency).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(InfoModel obj)
        {
            //An error page is used to refuse the register of models out of the minimum and maximum age.
            if (obj.Age < 15 || obj.Age > 23)
            {
                string message;
                if (obj.Age < 15)
                {
                    message = "Mano, tu tem que ter pelo menos 15 anos pra se cadastrar";
                }
                else
                {
                    message = "Mano, tu ta velha demais pra cadastrar nessa agencia";
                }
                throw new IntegrityException(message);
            }

            _barbieContext.Add(obj);
            await _barbieContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(InfoModel obj)
        {
            bool hasAny = await _barbieContext.InfoModels.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                return;
            }
            try
            {
                _barbieContext.Update(obj);
                await _barbieContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                return;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _barbieContext.InfoModels.FindAsync(id);
                _barbieContext.InfoModels.Remove(obj);
                await _barbieContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return;
            }
        }
    }
}
