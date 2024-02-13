using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

public class BaseService<TViewModel, TEntity, TInputModel> : IBaseService<TViewModel, TInputModel>
    where TViewModel : class
    where TEntity : class
    where TInputModel : class
{
    protected readonly ResTICDbContext _context;
    private readonly IMapper _mapper;

    public BaseService(ResTICDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TViewModel> InsertAsync(TInputModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TViewModel>(entity); 
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TViewModel> UpdateAsync(int id, TInputModel model)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new NotImplementedException();
        }

        _mapper.Map(model, entity);
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> GetAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<IEnumerable<TViewModel>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return _mapper.Map<IEnumerable<TViewModel>>(entities);
    }
}