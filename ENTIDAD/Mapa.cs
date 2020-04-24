using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD
{
   public class Mapa{
        
     
        public string latitudOrigen { get; set; }

 
        public string longitudOrigen { get; set; }

        public string latitudDestino { get; set; }


        public string longitudDestino { get; set; }

        public Mapa()
        {
        }

     
        public Mapa(string latitudOrigen, string longitudOrigen)
        {
            this.latitudOrigen = latitudOrigen;
            this.longitudOrigen = longitudOrigen;
          
        }
    }
}
