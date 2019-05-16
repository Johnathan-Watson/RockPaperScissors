using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Models
{
    public partial class FormContext : DbContext
    {
        // http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        public FormContext() : base("name=FormContext")
        {
            Database.SetInitializer<FormContext>(new DropCreateDatabaseIfModelChanges<FormContext>());
        }
        public virtual DbSet<Results> Result { get; set; }
        public DateTime Time { get; internal set; }
    }
}
