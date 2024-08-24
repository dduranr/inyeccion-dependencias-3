using InyeccionDeDependencias3.Misc.Interfaces;

namespace InyeccionDeDependencias3.Misc
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"El mensaje es: \"{message}\")");
        }
    }
}
