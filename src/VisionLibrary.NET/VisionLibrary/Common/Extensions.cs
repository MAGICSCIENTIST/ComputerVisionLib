using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisionLibrary.Common
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
        /// <summary>  
        /// 获取枚举的备注信息  
        /// </summary>  
        /// <param name="em"></param>  
        /// <returns></returns>  
        public static string GetEnumDescription(this System.Enum em)
        {
            string str = em.ToString();
            FieldInfo field = em.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            DescriptionAttribute da = (DescriptionAttribute)objs[0];
            return da.Description;
        }
    }
}
