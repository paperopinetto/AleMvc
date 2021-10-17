using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AleMvc.Models
{
    public class Nuoviutenti
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo richiesto")]
        //[FulllName(ErrorMessage ="Non puoi specificare 2 nomi propri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Password richiesto")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        








    }
}
