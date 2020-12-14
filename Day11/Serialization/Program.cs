using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 - Serialization allow us to store objects and variables into file so that it will be available even our program is not running
 - Deserialzation allow us to read objects and variable from the file so that we can create an object again and use that into our program
 - Formatters are the way of storing objects and variables (not properties) into the file like Binary,Xml,Soap,Json and custom serialization

 - If we want to serialize an class then add attribute [Serializable] over the class

 - Xml formatter is little different becoz by default it stores only public variables and properties also, to change this behaviour use custom serialization
 - We can set [xmlAttribute] and [xmlElement] to decide which varible or property should be stored as xml-attribute or xml-element
 - For custom serialization we need to implement ISerializable interface
*/

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
