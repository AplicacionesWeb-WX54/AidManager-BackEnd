using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.ManageCosts.Infraestructure.Repositories;

public class AnalyticRepository: BaseRepository<Analytic>, IAnalyticRepository
{
    public AnalyticRepository(AppDBContext context): base(context) {}
    
    public Task<Analytic> CreateAnalytic(Analytic entity)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                Context.Set<Analytic>().Add(entity);
                Context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("Analytic created successfully");
                return Task.FromResult(entity);
            }
            catch(Exception)
            {
                Console.WriteLine("Error creating analytic");
                transaction.Rollback();
            }
            return Task.FromResult<Analytic>(null);
        }
    }
    
    
    
    public Task<List<Analytic>> GetAllAnalytics(int projectId)
    {
        return Context.Set<Analytic>().Where(f => f.ProjectId == projectId).ToListAsync();

    }
    
    public Task<List<Analytic>> FindByProjectIdAsync(int projectId)
    {
        return Context.Set<Analytic>().Where(f => f.ProjectId == projectId).ToListAsync();
    }
    

    public async Task<IEnumerable<Analytic>> FindAllAsync()
    {
        Console.WriteLine("find all in AnalyticRepository");
        return await Context.Set<Analytic>().ToListAsync();
    }

    public async Task<IEnumerable<Analytic>> FindByIdAsync(int Id)
    {
        Console.WriteLine("find by id in AnalyticRepository");
        return await Context.Set<Analytic>().Where(a => a.Id == Id).ToListAsync();
    }
}