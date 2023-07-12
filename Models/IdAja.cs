using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class IdAja
    {
        public int id;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
