using Sistran.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sistran.DataAccess
{
    public class PersonsRepository : IPersonsRepository
    {

        public async Task<Response<Person_Entity>> CreatePerson(Person_Input param)
        {
            Response<Person_Entity> result = new Response<Person_Entity>();

            result.Content = new List<Person_Entity>();

            try
            {
                //============================================================================================
                //AQUÍ EL CÓDIGO (LLAMADA AWAIT + MAPPING DEL RESPONSE) A BD PARA INSERTAR REGISTRO DE PERSONA
                //============================================================================================

                //A efectos del ejercicio se "mockea" un obj Person_Entity correcto como respuesta dummy de inserción correcta en BD... 

                Random rnd = new Random();

                result.Content.Add(new Person_Entity { 
                    Id = rnd.Next(1024),
                    LastNames = param.LastNames,
                    Names = param.Names,
                    IdentityDoc = param.IdentityDoc,
                    DateOfBirth = param.DateOfBirth,
                    ContactInfo = param.ContactInfo
                });

            }
            catch (Exception err)
            {
                result.ErrorCode = "E01";
                if (err.InnerException != null)
                    result.SystemMsg = err.Message;
                else
                    result.SystemMsg = err.Message;
                result.HumanMsg = "Hubo un inconveniente al crear el nuevo registro.";
                result.Content = null;
            }

            return result;

        }

        /// <summary>
        /// Recupera de BD una persona según su documento de identidad
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Response<Person_Entity>> GetPersonByIdentityDoc(Person_Input param)
        {
            Response<Person_Entity> result = new Response<Person_Entity>();

            result.Content = new List<Person_Entity>();

            try
            {
                //============================================================================================
                //AQUÍ EL CÓDIGO (LLAMADA AWAIT + MAPPING DEL RESPONSE) A BD PARA RECUPERAR UN REGISTRO DE PERSONA SEGÚN SU DOCUMENTO DE IDENT.
                //============================================================================================

                //A efectos del ejercicio se "mockea" un obj Person_Entity correcto como respuesta dummy de inserción correcta en BD cuando el input es igual a "1"... 

                if (param.IdentityDoc == "1")
                {
                    result.Content.Add(new Person_Entity
                    {
                        Id = 99,
                        LastNames = param.LastNames,
                        Names = param.Names,
                        IdentityDoc = param.IdentityDoc,
                        DateOfBirth = param.DateOfBirth,
                        ContactInfo = param.ContactInfo
                    });
                }
                

            }
            catch (Exception err)
            {
                result.ErrorCode = "E01";
                if (err.InnerException != null)
                    result.SystemMsg = err.Message;
                else
                    result.SystemMsg = err.Message;
                result.HumanMsg = "Hubo un inconveniente al recuperar persona (Num. Identificación: "+ param.IdentityDoc +").";
                result.Content = null;
            }

            return result;

        }

    }
}
