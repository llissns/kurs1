using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurrab.Classes
{
    internal class AccessRight
    {
        string group, create, delete, read, administer, upload;
        public AccessRight(string _group, string _create, string _delete, string _read, string _administer, string _upload)
        {
            group = _group;
            create = _create;
            delete = _delete;
            read = _read;
            administer = _administer;
            upload = _upload;
        }   
    }
}
