using System;

namespace com.iiosworld.service.webapi.models
{
    public class UniqueIdentifier
    {
        private string _idValue = null;
        private const string EMSG_UID_NO_OVERWRITE = @"Cannot overwrite an existing unique identifier for an object.";
        private const string EMSG_UID_PARSE_ERR = @"Error encountered trying to parse the parameter 'pUniqueIdentifier' for constructor, check inner the Exception for details.";

        public UniqueIdentifier()
        {
            if(this._idValue==null)
            {
                this._idValue = Guid.NewGuid().ToString();
            }
        }
        public UniqueIdentifier(string pUniqueIdentifier)
        {
            if (this._idValue == null)
            {
                try
                {
                    this._idValue = Guid.Parse(pUniqueIdentifier).ToString();
                }
                catch (Exception originEx)
                {

                    throw new ArgumentException(EMSG_UID_PARSE_ERR, originEx);
                }
                
            }
            else
            {
                throw new ArgumentException(EMSG_UID_NO_OVERWRITE);
            }
        }
        public string IdValue { get => _idValue; }
    }
}
