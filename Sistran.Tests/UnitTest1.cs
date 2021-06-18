using Sistran.BusinessActions;
using Sistran.BusinessObjects;
using Sistran.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sistran.Tests
{ 
    public class CreatePersonEndpoint_Should
    {
        private readonly IPersonsRepository _context;

        [Fact]
        public void Given_A_Valid_Person_Input_Mock_Obj_Insert_A_Propper_Person_Entity_In_BD()
        {
            Person_Input validEntityMock = new Person_Input
            {
                DateOfBirth = new DateTime(1984,01,04),
                IdentityDoc = "doc_321",
                LastNames = "Yañez Pérez",
                Names = "Carlos Alberto",
                ContactInfo = new ContactInfo_Entity
                {
                     EmailAddresses = new List<string> { "email1@correo.com", "email2@correo.com"},
                     HomeAddresses = new List<string> { "Su casa, su calle, su ciudad." },
                     PhoneNumbers = new List<string> { "054111111111" },
                }
            };

            Person_Entity _fromMock = new Person_Entity
            {
                Id = validEntityMock.Id,
                DateOfBirth = validEntityMock.DateOfBirth,
                IdentityDoc = validEntityMock.IdentityDoc,
                Names = validEntityMock.Names,
                LastNames = validEntityMock.LastNames,
                ContactInfo = validEntityMock.ContactInfo
            };

            PersonsActions personaService = new PersonsActions(_context);

            Response<Person_Entity> resultPersonEntity = personaService.CreatePerson(validEntityMock).Result;

            Assert.Same(validEntityMock, resultPersonEntity.Content[0]);
        }
    }
}
