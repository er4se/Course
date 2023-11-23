using System;

namespace DSL_MVP
{
    public class Model
    {
        private string DB_Data;

        public string DB_Connect(string s)
        {
            DB_Data = s;
            return string.Format("Работа: Model.Logic({0})", DB_Data);
        }
    }
}