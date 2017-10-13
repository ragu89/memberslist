using System.Collections.Generic;
using System.Threading.Tasks;

namespace MembersList
{
    public interface IDataStore<T>
    {
        Task<bool> AddPersonAsync(T person);
        Task<bool> UpdatePersonAsync(T person);
        Task<bool> DeletePersonAsync(string id);
        Task<T> GetPersonAsync(string id);
        Task<IEnumerable<T>> GetPersonsAsync(bool forceRefresh = false);
    }
}
