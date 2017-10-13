using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eCTD_Diagnostic
{
    public static class XMLToolbox
    {
        public static bool TreeHasSingleChildNodes(XElement x)
        {
            bool returnValue = false;
          
            // Counts the number of roots child nodes
            int childrenCount = x.Elements().Count();

            // If the root node has only 1 child
            if (childrenCount == 1)
            {
                if(x.Elements().ElementAt(0).Elements().Count() == 0)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < childrenCount; i++)
                    {
                        returnValue = TreeHasSingleChildNodes(x.Elements().ElementAt(i));
                    }
                }
            }
            // If there are more than one child
            else if(childrenCount > 1)
            {
                for (int i = 0; i < childrenCount; i++)
                {
                    returnValue = TreeHasSingleChildNodes(x.Elements().ElementAt(i));

                    if(!returnValue)
                    {
                        return false;
                    }
                }
            }

            return returnValue;
        }
    }
}
