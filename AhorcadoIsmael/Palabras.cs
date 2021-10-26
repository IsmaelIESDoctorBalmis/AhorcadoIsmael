using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoIsmael
{
    class Palabras
    {

        protected Palabras()
        {
        }



        public static readonly List<String> palabrasFaciles = new List<string>(){

            "caca",
            "perro",
            "mesa"

        };


        public static readonly List<String> palabrasMedias = new List<string>(){

            "mochila",
            "programacion",
            "ordenador"

        };

        public static readonly List<String> palabrasDificiles = new List<string>(){

            "esternocleidomastoideo",
            "estrabismo",
            "maricon"


        };

        public static List<String> palabrasUsuario = new List<string>();




    }
}
