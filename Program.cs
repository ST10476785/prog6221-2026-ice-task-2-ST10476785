
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

        public class VocalResponse : ShipCommand {  //  Step 2  Child class vocalResponse, inherits from ShipCommand, overrides executeCommand method

            public int? AlertPitch { get; set; }  //nullable int that will be used to adjust frequency


            public override void ExecuteCommand() // override method to adjust pitch of vocal response based on The AlertPitch int
            {
                using (SpeechSynthesizer speechsynthesizer = new SpeechSynthesizer())
                {
                    if (AlertPitch == null) // if null synthesizer pitch will be normal as a default
                    {
                        Console.WriteLine("Mode: Standard Communication.");
                        speechsynthesizer.Rate = 0;
                        speechsynthesizer.Speak(InputText);
                    }
                    else
                    {
                        Console.WriteLine("Mode: Priority Alert (Pitch Level: " + AlertPitch + ")");
                        speechsynthesizer.Rate = AlertPitch.Value;
                        speechsynthesizer.Speak(InputText); // if not null the pitch is adjusted based of the alertPitch int
                    }
                }
            }



        }


        

    
        
            
        
        static void Main(string[] args)
        {

            //Step 3 Main method to prompt user input for rank, name and the command that will be spoken by the speechsynthesizer
            Console.Write("Enter your rank and name (e.g., Captain Miller: ");
            var userName = Console.ReadLine();

            Console.Write("Enter your command: ");
            var commandText = Console.ReadLine();

            // String Methods for LogCode
            string formattedName = userName.Trim().Replace(" ", "").ToUpper();
            string formattedCommand = commandText.Trim().Replace(" ", "").ToUpper();

            var logCode = formattedName + "-" + formattedCommand;

            // Handling Nullables
            Console.Write("Enter Alert Urgency (1 to 10) or leave empty for Standard Mode: ");
            string urgencyInput = Console.ReadLine();

            int? pitchLevel = null;

            if (!string.IsNullOrWhiteSpace(urgencyInput) && int.TryParse(urgencyInput, out int parsedPitch))
            {
                pitchLevel = parsedPitch; 
            }

        }
    }
}
