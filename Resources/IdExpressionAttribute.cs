using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfPocAPI.Resources
{
    public class IdExpressionAttribute : Attribute
    {
        /// <summary>
        /// CAT_AGRUPA_TEXTO_PSW.CD_AGRUPA from PSW database
        /// </summary>
        public int IdExpression { get; private set; }

        public IdExpressionAttribute(int id)
        {
            IdExpression = id;
        }
    }
}
