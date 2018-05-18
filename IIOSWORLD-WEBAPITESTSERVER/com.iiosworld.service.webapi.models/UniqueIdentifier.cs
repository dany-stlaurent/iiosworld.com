using System;

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
                this._idValue = Guid.Parse(pUniqueIdentifier).ToString();
            }
            else
            {
                throw new ArgumentException(@"Cannot overwrite an existing unique identifier for an object.");
            }
        }
        public string IdValue { get => _idValue; }
    }
}
