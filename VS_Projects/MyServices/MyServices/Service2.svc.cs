using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public static List<string> returnedList = new List<string>();

        public void DeleteQuestion(List<string> someList, int Id)
        {
            returnedList = someList;
            returnedList.RemoveAt(Id);
        }

        public void EditQuestion(List<string> someList, int Id, string someItem)
        {
            returnedList = someList;
            returnedList[Id] = someItem;
        }

        public List<string> GetQuestion(List<string> someList)
        {
            for(int i = 0; i < someList.Count; i++)
            {
                returnedList[i] = someList[i]; 
            }
            return returnedList;
        }

        public void AddQuestion(List<string> someList, string someItem)
        {
            returnedList = someList;
            returnedList.Add(someItem);
        }
    }
}
