using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AnObjectResult<T>
    {
        public List<T> Object { get; set; }
        public bool Succeeded { get; set; }
        public List<string> ErrorMessages { get; set; }

        public AnObjectResult(List<T> theObject, bool succeeded, List<string> errorMessages)
        {
            Object = theObject;
            Succeeded = succeeded;
            ErrorMessages = errorMessages;
        }

        public AnObjectResult(bool succeded, List<string> errorMessages)
        {
            Object = null;
            Succeeded = succeded;
            ErrorMessages = errorMessages;
        }

        public static AnObjectResult<T> ReturnObjectResult(bool succeded, List<string> errorMessages) => new(succeded, errorMessages);

        public static AnObjectResult<T> ReturnObjectResult(bool succeded, string errorMessage) => new(succeded, ReturnObjectList(errorMessage));

        public static AnObjectResult<T> ReturnObjectResult(List<T> theObject, bool succeeded, List<string> errorMessages) => new(theObject, succeeded, errorMessages);

        public static AnObjectResult<T> ReturnObjectResult(List<T> theObject, bool succeeded, string errorMessage) => new(theObject, succeeded, ReturnObjectList(errorMessage));

        public static AnObjectResult<T> ReturnObjectResult(T theObject, bool succeeded, string errorMessage) => new(ReturnObjectList(theObject), succeeded, ReturnObjectList(errorMessage));

        public static AnObjectResult<T> ReturnObjectResult(T theObject, bool succeeded, List<string> errorMessages) => new(ReturnObjectList(theObject), succeeded, errorMessages);

        public static List<T> ReturnObjectList<T>(T obj) => new() { obj };
    }
}
