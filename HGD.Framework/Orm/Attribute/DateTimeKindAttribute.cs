using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Orm.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeKindAttribute : System.Attribute
    {
        private readonly DateTimeKind _kind;
        public DateTimeKindAttribute(DateTimeKind kind)
        {
            _kind = kind;
        }
        public DateTimeKind Kind
        {
            get { return _kind; }
        }
        public static void Apply(object entity)
        {
            if (entity == null)
                return;

            //Find all properties that are of type DateTime or DateTime?;
            var properties = entity.GetType().GetProperties()
                .Where(x => x.PropertyType == typeof(DateTime)
                            || x.PropertyType == typeof(DateTime?));

            foreach (var property in properties)
            {
                //Check whether these properties have the DateTimeKindAttribute;
                DateTimeKindAttribute attr = (DateTimeKindAttribute)System.Attribute.GetCustomAttribute(property, typeof(DateTimeKindAttribute));
                if (attr == null)
                    continue;

                var dt = property.PropertyType == typeof(DateTime?)
                    ? (DateTime?)property.GetValue(entity)
                    : (DateTime)property.GetValue(entity);

                if (dt == null)
                    continue;

                //If the value is not null set the appropriate DateTimeKind;
                property.SetValue(entity, DateTime.SpecifyKind(dt.Value, attr.Kind));
            }
        }
    }
}
