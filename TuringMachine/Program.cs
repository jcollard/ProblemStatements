using System;
using System.Collections.Generic;

class Solution
{ 
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int S = int.Parse(inputs[0]); // Symbols
        int T = int.Parse(inputs[1]); // Tape Length
        int X = int.Parse(inputs[2]); // init Position
        string START = Console.ReadLine(); // Initial State
        int N = int.Parse(Console.ReadLine());

        TuringMachine machine = new TuringMachine(T, START, X);
        machine.InstructionTable = new Instruction[N,S];

        for (int r = 0; r < N; r++)
        {
            string InstructionRow = Console.ReadLine();
            string StateLabel = InstructionRow.Split(":")[0];
            machine.StateToIndex[StateLabel] = r;
            string[] InstructionColumns = InstructionRow.Split(":")[1].Split(";");
            for (int c = 0; c < S; c++)
            {
                machine.InstructionTable[r,c] = new Instruction(InstructionColumns[c]);
            }
            
        }

        while (!machine.Step());
        Console.WriteLine(machine.Counter);
        Console.WriteLine(machine.Position);
        Console.WriteLine(machine.Tape);
    }

    class TuringMachine
    {
        internal Instruction[,] InstructionTable;
        internal Dictionary<string, int> StateToIndex = new Dictionary<string, int>();
        private readonly int[] tape;
        internal string State {get; set;}
        internal string Tape => string.Join("", tape);
        internal int Position {get; set;}
        internal bool Halted => Position < 0 || Position >= tape.Length || State == "HALT";
        private int Symbol => tape[Position];
        private int StateIx => StateToIndex[State];
        internal int Counter {get; private set;}

        public TuringMachine(int tapeLength, string initState, int initHead)
        {
            this.tape = new int[tapeLength];
            this.State = initState;
            this.Position = initHead;
            this.Counter = 0;
        }

        public void Write(int i) => tape[Position] = i;

        public bool Step()
        {
            if (Halted) return true;
            InstructionTable[StateIx, Symbol].Execute(this);
            Counter++;
            return Halted;
        }
    }

    class Instruction
    {
        private readonly int symbol;
        private string direction;
        private string next;
        public Instruction(string raw)
        {
           string[] split = raw.Split();
           symbol = int.Parse(split[0]);
           direction = split[1];
           next = split[2];
        }

        public void Execute(TuringMachine m)
        {
            m.Write(symbol);
            if (direction == "L") m.Position--;
            else m.Position++;
            m.State = next;
        }
    }
}