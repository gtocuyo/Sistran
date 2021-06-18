using Sistran.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sistran.DataAccess
{
    public interface IPersonsRepository
    {
        Task<Response<Person_Entity>> CreatePerson(Person_Input param);

        Task<Response<Person_Entity>> GetPersonByIdentityDoc(Person_Input param);
    }
}
