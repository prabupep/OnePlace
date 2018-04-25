using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePlace.Web.Models
{
    public static class CommonModel
    {
        static string[] DatePropertyName = new string[2] { "CreatedOn", "ModifiedOn" };
        static string[] UserPropertyName = new string[2] { "CreatedBy", "ModifiedBy" };
        public static Guid GetNewGUIDIfEmpty(Guid value)
        {
            if (value == Guid.Empty)
            {
                return Guid.NewGuid();
            }
            else
            {
                return value;
            }
        }

        public static T AssigneLoginInfo<T>(T model)
        {
            var type = model.GetType();
            foreach (var item in DatePropertyName)
            {
                if (type.GetProperty(item) != null)
                {
                    var property = model.GetType().GetProperty(item);
                    property.SetValue(model, DateTime.Now);
                }
            }
            foreach (var item in UserPropertyName)
            {
                if (type.GetProperty(item) != null)
                {
                    var property = model.GetType().GetProperty(item);
                    property.SetValue(model, "Anonymous");
                }
            }

            return model;



        }
    }
}