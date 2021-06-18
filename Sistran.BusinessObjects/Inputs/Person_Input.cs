using System;
using System.Collections.Generic;
using System.Text;

namespace Sistran.BusinessObjects
{
    public partial class Person_Input
    {
        #region Fields
        private Int64 _Id;

        private string _IdentityDoc;

        private string _Names;

        private string _LastNames;

        private DateTime _DateOfBirth;

        private ContactInfo_Entity _ContactInfo;
        #endregion

        #region Properties
        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string IdentityDoc
        {
            get { return _IdentityDoc; }
            set { _IdentityDoc = value; }
        }

        public string Names
        {
            get { return _Names; }
            set { _Names = value; }
        }

        public string LastNames
        {
            get { return _LastNames; }
            set { _LastNames = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public ContactInfo_Entity ContactInfo
        {
            get { return _ContactInfo; }
            set { _ContactInfo = value; }
        }
    }

    #endregion

}
