
using System.Speech.Synthesis;
namespace ICE_TASK_2
{
    internal class Program
    {


        public class ShipCommand {
            // Step 1 ship command class automatic properties (getters and setters) and executeCommand method

            public String InputText { get; set; }
            public String AuthorizedUser { get; set; }




            public virtual void ExecuteCommand() {
                Console.WriteLine("Processing Command");

                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

                speechSynthesizer.Speak("Command receieved");

            }



        }
        static void Main(string[] args)
        {
      
        }
    }
}
