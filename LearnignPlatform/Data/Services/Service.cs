using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new ApplicationDbContext();
        }
        protected ApplicationDbContext Context { get; }
    }
}
