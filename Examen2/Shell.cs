using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    class Shell
    {
        private readonly Commands _commands;
        private readonly Dictionary<string, Action<string, string>> _shellCommands;

        public Shell()
        {
            _commands = new Commands();
            _shellCommands = PopulateDictionary();
        }

        public void RunShell()
        {
            Console.Out.WriteLine("Usage: <command> <inputfile> -o <outputfile>");
            Console.Out.WriteLine("Usage: <inputfile>");
            Console.Out.WriteLine("where <command> is one of: \n" +
                                  "      tojson, toxml\n" +
                                  "default: tojson");

            while (true)
            {
                var input = Console.ReadLine();
                if (input == null) continue;
                var commands = input.Split(' ');

                string inputfile;
                string outputfile;
                string command;

                SetArguments(commands, out inputfile, out command, out outputfile);

                if (commands[0].ToLower().Equals("exit"))
                    break;

                if (_shellCommands.ContainsKey(command))
                {
                    _shellCommands[command].Invoke(inputfile, outputfile);
                    Console.Out.WriteLine("");
                }
                else
                    Console.WriteLine("Comando Invalido");
            }
        }

        private static void SetArguments(IReadOnlyList<string> input, out string inputfile, out string command, out string outputfile)
        {
            if (input.Count == 1 && input[0].ToLower().Contains('.'))
            {
                inputfile = input[0];
                command = "tojson";
                outputfile = "./output.json";
            }
            else if (input.Count == 4)
            {
                command = input[0];
                inputfile = input[1];
                outputfile = input[3];
            }
            else
            {
                inputfile = "";
                command = "";
                outputfile = "";
            }
        }

        private Dictionary<string, Action<string, string>> PopulateDictionary()
        {
            var actions = new Dictionary<string, Action<string, string>>
            {
                {"toxml", _commands.ToXML},
                {"tojson", _commands.ToJSON}
            };

            return actions;
        }
    }
}
