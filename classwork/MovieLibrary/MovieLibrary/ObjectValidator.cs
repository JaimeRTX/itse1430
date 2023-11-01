using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary;

public class ObjectValidator
{
    public bool TryValidate( IValidatableObject value, out IEnumerable<ValidationResult> results)
    {
        var context = new ValidationContext(value);
        var items = new System.Collections.ObjectModel.Collection<ValidationResult>();
        if (Validator.TryValidateObject(value, context, items, true))
        {
            results = new ValidationResult[0];
            return true;
        };
        results = items;
        return false;
    }
}
