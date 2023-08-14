using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Domain.Validation
{
    public class ValidationDomain : Exception
    {
        public ValidationDomain(string error) : base(error)
        {}

        public static void When(bool HasError, string error)
        {
            if (HasError) throw new ValidationDomain(error);
        }
    }
}
