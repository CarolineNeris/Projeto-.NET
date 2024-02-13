public interface IBaseService<TViewModel, TInputModel>
    where TViewModel : class
    where TInputModel : class
{
    Task<TViewModel> InsertAsync(TInputModel model);
    Task<bool> DeleteAsync(int id);
    Task<TViewModel> UpdateAsync(int id, TInputModel model);
    Task<TViewModel> GetAsync(int id);
    Task<IEnumerable<TViewModel>> GetAllAsync();
}