using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AleMvc.Models
{
    public class Lezioni
    {
        public int ID { get; set; }
        public int Id_lezione{ get; set; }
        [Required(ErrorMessage = "Campo richiesto")]
        //[FulllName(ErrorMessage ="Non puoi specificare 2 nomi propri")]
        

        public string TitoloLezione { get; set; }

        [Required(ErrorMessage = "Password richiesto")]
        [DataType(DataType.Password)]
        public string Docente { get; set; }
        public int Id_Docente { get; set; }
        
        public virtual Nuoviutenti utente { get; set; }







    }
}
