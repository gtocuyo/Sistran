using System;
using System.Collections.Generic;

namespace Sistran.BusinessObjects
{
    public partial class ContactInfo_Entity
    {
        #region Fields
        private List<String> _PhoneNumbers;

        private List<String> _EmailAddresses;

        private List<String> _HomeAddresses;
        #endregion

        #region Properties
        public List<String> PhoneNumbers 
        {
            get { return _PhoneNumbers; }
            set { _PhoneNumbers = value; }
        }

        public List<String> EmailAddresses
        {
            get { return _EmailAddresses; }
            set { _EmailAddresses = value; }
        }

        public List<String> HomeAddresses
        {
            get { return _HomeAddresses; }
            set { _HomeAddresses = value; }
        }

        #endregion


    }
}
