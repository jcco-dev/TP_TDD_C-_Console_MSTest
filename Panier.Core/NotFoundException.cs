using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
