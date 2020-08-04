using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.portfolioappraisal
{
    public class PortfolioappraisalModel
    {

        public string Security { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> Gain_Loss { get; set; }
        public Nullable<decimal> Gain_LossPer { get; set; }
        public Nullable<decimal> PerAsstes { get; set; }

    }

    public class SumPortfolioappraisalModel
    {
        public Nullable<decimal> SumCost { get; set; }
        public Nullable<decimal> SumMarketValue { get; set; }
        public Nullable<decimal> SumGain_Loss { get; set; }
        public Nullable<decimal> SumGain_LossPer { get; set; }
        public Nullable<decimal> SumPerAsstes { get; set; }
       
    }





    public class cashportfolio
    {
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> Gain_Loss { get; set; }
        public Nullable<decimal> Gain_LossPer { get; set; }
        public Nullable<decimal> PerAsstes { get; set; }
        

    }


    public class Sumcashportfolio {

        public Nullable<Int32> cash { get; set; }

    }




    public class HDATE
    {
        public Int32 ID { get; set; }
        public string Date { get; set; }

    }


    public class GridFields
    {
        public string CustomerAccountno { get; set; }
        public string UserID { get; set; }
        public string Fromdate { get; set; }
        public string pagecount { get; set; }

    }


    //public class IsFutureportfolio
    //{
    //    public string Quantity { get; set; }
    //    public string UnitCost { get; set; }
    //    public string Cost { get; set; }
    //    public string Price { get; set; }
    //    public string MarketValue { get; set; }
    //    public string Gain_Loss { get; set; }
    //    public string Gain_LossPer { get; set; }
    //    public string PerAsstes { get; set; }


    //}

}