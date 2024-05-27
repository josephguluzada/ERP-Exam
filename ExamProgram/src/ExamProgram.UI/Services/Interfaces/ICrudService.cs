namespace ExamProgram.UI.Services.Interfaces;

public interface ICrudService
{
    Task<T> GetByIdAsync<T>(string endpoint,int id);
    Task<T> GetAllAsync<T>(string endpoint);
    Task CreateAsync<T>(string endpoint,T model) where T : class;
    Task UpdateAsync<T>(string endpoint, T model) where T : class;   
    Task DeleteAsync(string endpoint, int id);
}
