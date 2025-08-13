using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestProject1
{
    internal class TestMethods
    {
        internal static uint StackFirstPrime(Stack<uint> stack)
        {
            foreach (uint num in stack)
            {
                if (IsPrime(num)) 
                    return num;   
            }
            return 0; 
        }

        internal static Stack<uint> RemoveFirstPrime(Stack<uint> stack)
        {
            Stack<uint> stackAux = new Stack<uint>();
            bool removed = false; // Para saber se eliminó un primo

            while (stack.Count > 0)
            {
                uint num = stack.Pop();

                if (!removed && IsPrime(num))
                {
                    removed = true; // Indica que ya se ha eliminado un primo
                    continue;       // no se guarda en la auxiliar
                }

                stackAux.Push(num);
            }

            while (stackAux.Count > 0) // se vuelve a llenar la pila original sin incluir el primer primo que ya se ha eliminado
            {
                stack.Push(stackAux.Pop());
            }

            return stack;
        }

        internal static Queue<uint> CreateQueueFromStack(Stack<uint> stack)
        {
            Queue<uint> queue = new Queue<uint>();

            foreach (uint num in stack)
            {
                queue.Enqueue(num); 
            }

            return queue;
        }

        internal static List<uint> StackToList(Stack<uint> stack)
        {
            List<uint> list = new List<uint>();

            foreach (uint num in stack)
            {
                list.Add(num);
            }

            return list;
        }

        internal static bool FoundElementAfterSorted(List<int> list, int value)
        {
            if (HasEvenCount(list))
            {
                BubbleSort(list);

                foreach (int num in list)
                {
                    if (num == value)
                        return true;
                }
                return false;

            }
            return false ;
        }

        internal static bool IsPrime(uint num)
        {

            if (num <= 1)
                return false;

            if (num == 2)
                return true;

            if (num % 2 == 0)
                return false;

            for (int i = 3; i <= (int)Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                    return false; // Si tiene un divisor, no es primo
            }

            return true; // Si no encontró divisores, es primo
        }

        internal static void BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        internal static bool HasEvenCount(List<int> list)
        {
            return list.Count % 2 == 0;
        }
    }
}