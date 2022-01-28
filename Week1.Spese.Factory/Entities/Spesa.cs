using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Week1.Spese.Factory.Entities
{
    public class Spesa
    {
        private DateTime _data;
        private CategoriaEnum _categoria;
        private string _descrizione;
        private double _importo;
        //private string _stato;

        public Spesa()
        {

        }

        //public Spesa(DateTime data, string descrizione, double importo, string stato)
        //{
        //    _data = data;
        //    _descrizione = descrizione;
        //    _importo = importo;
        //    _stato = stato;
        //}

        public DateTime Data 
        { 
            get { return _data; }
            set { _data = value; }
        }

        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value;}
        }

        public double Importo
        {
            get { return _importo; }
            set { _importo = value;}
        }

        public CategoriaEnum Category
        {
            get { return _categoria; }
            set { _categoria = value;}
        }
        //public string Stato
        //{
        //    get { return _stato; }
        //}

    }

    public enum CategoriaEnum
    {
        Viaggio = 1,
        Alloggio = 2,
        Vitto = 3,
        Altro = 4,
    }
}
