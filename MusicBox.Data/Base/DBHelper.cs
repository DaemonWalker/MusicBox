using System;
using System.Collections.Generic;
using System.Text;

namespace MusicBox.Data.Base
{
    public abstract class DBHelper<T> where T : new()
    {
        protected DBClass dbClass = DBClass.CreateDBClass();

        protected abstract List<T> ConvertDataTableToModels(DataTable dt);

        protected List<KeyValuePair<string, object>> CreateParms()
        {
            return new List<KeyValuePair<string, object>>();
        }
    }
}
