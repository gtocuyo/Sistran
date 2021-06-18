using Sistran.BusinessObjects;
using Sistran.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sistran.BusinessActions
{
    public class PersonsActions
    {

        private readonly IPersonsRepository _context;

        public PersonsActions(IPersonsRepository context)
        {
            _context = context;
        }

        public async Task<Response<Person_Entity>> CreatePerson(Person_Input param)
        {
            Response<Person_Entity> result = new Response<Person_Entity>();

            try
            {
                if(ValidaObjPersona(param))
                    result = await _context.CreatePerson(param);

                if (result.Content.Count > 0)
                {
                    result.HumanMsg = "Persona creada exitosamente!";
                    result.SystemMsg = "New Persona obj created at " + DateTime.Now;
                }
                else
                    throw new Exception("Se encontró un error no identificado en la creación de la nueva persona.");

                return result;

            }
            catch (Exception err)
            {
                result.Content = new List<Person_Entity>();
                result.ErrorCode = "E01";
                result.SystemMsg = "Error en la creación de la nueva persona: " + err.Message;
                result.HumanMsg = "Error en la creación de la nueva persona!";
                return result;
            }
        }

        /// <summary>
        /// Método que aplica las reglas de validación definidas para un obj persona que pueda insertarse en BD
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool ValidaObjPersona(Person_Input param)
        {
            bool canCreate = true;

            //Documento de identidad, nombres, apellidos y fecha nacimiento son obligatorios...
            if (string.IsNullOrEmpty(param.IdentityDoc) || (param.DateOfBirth == null) || string.IsNullOrEmpty(param.Names) || string.IsNullOrEmpty(param.LastNames))
                throw new Exception("Documento de identidad, nombres, apellidos y fecha nacimiento son obligatorios.");

            //Al menos debe registrar una información de contacto...
            if (param.ContactInfo == null ||
                (param.ContactInfo.EmailAddresses != null && param.ContactInfo.EmailAddresses.Count == 0) ||
                (param.ContactInfo.HomeAddresses != null && param.ContactInfo.HomeAddresses.Count == 0) ||
                (param.ContactInfo.PhoneNumbers != null && param.ContactInfo.PhoneNumbers.Count == 0)
              )
                throw new Exception("Al menos debe registrar una información de contacto (Dirección, email o teléfono).");

            //La cantidad máxima de emails es 2.
            if (param.ContactInfo.EmailAddresses != null && param.ContactInfo.EmailAddresses.Count > 2)
                throw new Exception("La cantidad máxima de correos electronicos permitida es dos (2).");

            //La cantidad máxima de teléfonos es 2.
            if (param.ContactInfo.PhoneNumbers != null && param.ContactInfo.PhoneNumbers.Count > 2)
                throw new Exception("La cantidad máxima de teléfonos permitida es dos (2).");

            //La cantidad máxima de direcciones es 2.
            if (param.ContactInfo.HomeAddresses != null && param.ContactInfo.HomeAddresses.Count > 2)
                throw new Exception("La cantidad máxima de direcciones físicas permitida es dos (2).");

            if(param.ContactInfo.EmailAddresses != null && !CommonUtils.ValidaListaEmail(param.ContactInfo.EmailAddresses))
                throw new Exception("Se encontró por lo menos un correo electrónico incorrecto.");

            if (param.ContactInfo.PhoneNumbers != null && !CommonUtils.ValidaListaTelefono(param.ContactInfo.PhoneNumbers))
                throw new Exception("Se encontró por lo menos un teléfono de contacto incorrecto.");

            //El documento de identidad sólo acepta valores alfanuméricos...
            if (!CommonUtils.SoloCaracteresAlfanumericos(param.IdentityDoc))
                throw new Exception("El documento de identidad sólo acepta valores alfanuméricos.");

            //Los nombres sólo deben contener caracteres alfanuméricos...
            if (!CommonUtils.SoloCaracteresAlfabeticosYLatinos(param.Names))
                throw new Exception("Los nombres sólo aceptan caracteres del alfabeto latino y no pueden contener valores numéricos.");

            //Los apellidos sólo deben contener caracteres alfanuméricos...
            if (!CommonUtils.SoloCaracteresAlfabeticosYLatinos(param.LastNames))
                throw new Exception("Los apellidos sólo aceptan caracteres del alfabeto latino y no pueden contener valores numéricos.");

            //Si no se puede recuperar del BD (por error en la consulta)...
            Response<Person_Entity> existingUser = _context.GetPersonByIdentityDoc(param).Result;

            if (!string.IsNullOrEmpty(existingUser.ErrorCode))
                throw new Exception(existingUser.HumanMsg);

            //No debe crearse un usuario con el mismo documento de identificación de otro existente...
            if (existingUser.Content != null && existingUser.Content.Count > 0)
                throw new Exception("Ya existe un usuario con el Documento de Identificación suministrado.");

            return canCreate;

        }

    }

}
