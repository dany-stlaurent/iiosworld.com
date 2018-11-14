using System;
using Microsoft.CSharp;

namespace com.iiosworld.service.webapi.models
{
    public class UniqueIdentifier
    {
        private string _idValue = null;
 
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

                    throw new ArgumentException(Resources.ResourceManager.GetString(@"emsg_uid_parse_err"), originEx);
                }
                
            }
            else
            {
                throw new ArgumentException(Resources.ResourceManager.GetString(@"emsg_uid_no_overwrite"));
            }
        }
        public string IdValue { get => _idValue; }
    }
}
