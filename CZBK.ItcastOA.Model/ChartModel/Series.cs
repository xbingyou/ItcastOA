using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Model.ChartModel
{
    public class normal
    {
        /// <summary>
        /// color
        /// </summary>
        public string color
        {
            get;
            set;

        }

    }
    public class itemStyle
    {
        /// <summary>
        /// normal
        /// </summary>
        public object normal
        {
            get;
            set;
        }
    }
    public class data
    {
        public string name
        {
            get;
            set;
        }
        public int value
        {
            get;
            set;
        }
        public object itemStyle
        {
            get;
            set;
        }
    }

    public class Series
    {
        /// <summary>
        /// sereis序列组id
        /// </summary>
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// series序列组名称
        /// </summary>
        public string name
        {
            get;
            set;
        }
        /// <summary>
        /// series序列组呈现图表类型(line、column、bar等)
        /// </summary>
        public string type
        {
            get;
            set;
        }
        /// <summary>
        /// series序列组的itemstyle
        /// </summary>
        public object itemStyle
        {
            get;
            set;
        }
        /// <summary>
        /// series序列组的数据为数据类型数组
        /// </summary>
        public List<object> data
        {
            get;
            set;
        }
    }
}
