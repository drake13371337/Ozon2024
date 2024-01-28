using System;

namespace Task6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<char, Command> commands = new Dictionary<char, Command>()
            {
                { 'R', Command.Right }, { 'L', Command.Left },
                { 'U', Command.Up }, { 'D', Command.Down },
                { 'B', Command.Home }, { 'E', Command.End },
                { 'N', Command.Enter }
            };
            bool valid = int.TryParse(Console.ReadLine(), out int actionCount);
            for (int i = 0; i < actionCount; i++)
            {
                List<char> inputString = Console.ReadLine().Select(o => o).ToList();
                Terminal newTerminal = new Terminal(commands);
                foreach (var currentChar in inputString)
                {
                    newTerminal.ProcessChar(currentChar);
                }

                newTerminal.Display();
                Console.WriteLine("-");
            }
        }

        public class Terminal
        {
            private Dictionary<char, Command> _commands;
            private List<List<char>> _memory;

            private (int, int) _carriage;
            
            public Terminal(Dictionary<char, Command> commands)
            {
                _commands = commands;
                _memory = new List<List<char>>() { new List<char>() };
                _carriage = (0, 0);
            }

            private (int, int) ValidateCarriageNextRLPosition( (int, int) position )
            {
                if (position.Item2 < 0 || position.Item2 > _memory[position.Item1].Count) return _carriage;
                return position;
            }
            
            private (int, int) ValidateCarriageNextUDPosition( (int, int) position )
            {
                if (position.Item1 < 0 || position.Item1 >= _memory.Count) return _carriage;
                
                _carriage = position;
                if (_carriage.Item2 > _memory[position.Item1].Count) _carriage = ValidateCarriageNextEndPosition();
                
                return _carriage;
            }

            private (int, int) ValidateCarriageNextHomePosition()
            {
                return (_carriage.Item1, 0);
            }
            
            private (int, int) ValidateCarriageNextEndPosition()
            {
                return (_carriage.Item1, _memory[_carriage.Item1].Count);
            }

            private (int, int) ValidateCarriageNextEnterPosition()
            {
                return (_carriage.Item1 + 1, 0);
            }

            private void InseertNewLineOnCarriage( (int, int) oldPosition)
            {
                List<char> toMove = new List<char>();
                if (_memory[oldPosition.Item1].Count != oldPosition.Item2)
                {
                    for (int i = oldPosition.Item2; i < _memory[oldPosition.Item1].Count; i++)
                    {
                        toMove.Add(_memory[oldPosition.Item1][i]);
                    }
                    _memory[oldPosition.Item1].RemoveRange(oldPosition.Item2, _memory[oldPosition.Item1].Count - oldPosition.Item2);
                }
                _memory.Insert(_carriage.Item1, toMove);
            }

            private void InputChar(char input)
            {
                _memory[_carriage.Item1].Insert(_carriage.Item2, input);
                MoveCarriage(Command.Right);
            }

            private void MoveCarriage(Command command)
            {
                switch (command)
                {
                    case Command.Right:
                    {
                        var newPosition = (_carriage.Item1, _carriage.Item2 + 1);
                        _carriage = ValidateCarriageNextRLPosition(newPosition);
                        break;   
                    }
                    case Command.Left:
                    {
                        var newPosition = (_carriage.Item1, _carriage.Item2 - 1);
                        _carriage = ValidateCarriageNextRLPosition(newPosition);
                        break;   
                    }
                    case Command.Up:
                    {
                        var newPosition = (_carriage.Item1 - 1, _carriage.Item2);
                        _carriage = ValidateCarriageNextUDPosition(newPosition);
                        break;   
                    }
                    case Command.Down:
                    {
                        var newPosition = (_carriage.Item1 + 1, _carriage.Item2);
                        _carriage = ValidateCarriageNextUDPosition(newPosition);
                        break;   
                    }
                    case Command.Home:
                    {
                        _carriage = ValidateCarriageNextHomePosition();
                        break;   
                    }
                    case Command.End:
                    {
                        _carriage = ValidateCarriageNextEndPosition();
                        break;   
                    }
                    case Command.Enter:
                    {
                        var oldCarriage = (_carriage.Item1, _carriage.Item2);
                        _carriage = ValidateCarriageNextEnterPosition();
                        InseertNewLineOnCarriage(oldCarriage);
                        break;   
                    }
                }
            }

            public void Display()
            {
                string result = String.Empty;
                foreach (var row in _memory)
                {
                    foreach (var cell in row)
                    {
                        result += cell;
                    }
                    Console.WriteLine(result);
                    result = String.Empty;
                }
            }

            public void ProcessChar(char input)
            {
                if (_commands.TryGetValue(input, out Command command))
                    MoveCarriage(command);
                else
                    InputChar(input);
            }
        }

        public enum Command
        {
            Right,
            Left,
            Up,
            Down,
            Home,
            End,
            Enter
        }
    }
}