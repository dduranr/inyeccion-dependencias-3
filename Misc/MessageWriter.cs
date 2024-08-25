using InyeccionDeDependencias3.Misc.Interfaces;
using System.Diagnostics;

namespace InyeccionDeDependencias3.Misc
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Trace.WriteLine($"El mensaje es: \"{message}\")");
        }
    }
}
