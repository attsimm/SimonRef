using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpClass
{
    public class TSql
    {
        private string ConnectionString;
        public enum TSqlErrors { Success, Error, Warning };
        public TSql()
        {
            ConnectionString = string.Empty;
        }
        public TSql(string cstring)
        {
            ConnectionString = cstring;
        }
        public class Parameters
        {
            public string ParameterAlias { get; set; }
            public string Value { get; set; }
        }
        public class TSqlError
        {
            public TSqlErrors ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public Exception CompleteErrorObject { get; set; }
        }
        public class CommandResult
        {
            public TSqlError Error { get; set; }
            public SqlDataReader OriginalReader { get; set; }
            public string OriginalQuery { get; set; }
            public bool IsEmpty { get; set; }
        }
    }
}
