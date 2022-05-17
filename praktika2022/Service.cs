namespace praktika2022.DB1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public partial class Service
    {
        DB1.Model1 gg = new DB1.Model1();  
       
        public string Textdiscount
        {
            get
            {
                if ( Discount ==0 )
                {
                    return null;
                }
                else
                {
                    return "Скидка" + (Discount * 100).ToString() + "%";    
                }
            }
        }
        public string Turecena
        {
            get
            {
                if (Textdiscount == null)
                {
                    return Math.Round(Cost,2).ToString() + "Рублей";
                }
                else
                {
                     var f = (float)Cost * (1-Discount);
                    return f.ToString() +  ""+ "Рублей";
                }
            }
        }
        public string ColorService
        {
            
            get
            {
                if (Textdiscount == null)
                {
                    return "White";

                }
                else
                {
                    return "LightGreen";
                }
            }
        }

        public string imageservice
        {
            get
            {
                if (MainImagePath != null)
                {
                    return MainImagePath;

                }
                else if (MainImagePath == "не задано")
                {
                    return @"Услуги школы\standart.jpg";
                }
                else
                {
                    return @"Услуги школы\standart.jpg";
                }
            }
        }
       

    }
}
