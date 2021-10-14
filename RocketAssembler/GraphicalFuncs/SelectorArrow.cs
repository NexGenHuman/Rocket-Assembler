using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketAssembler.GraphicalFuncs
{
    class SelectorArrow
    {
        private string arrow = "->";
        private Tuple<int, int> prevPos;
        int range;
        public int current = 0;
        int space;


        public SelectorArrow(Tuple<int, int> pos, int _range, int _space)
        {
            range = _range;
            space = _space;
            reDrawArrow(pos);
        }

        public void moveArrow(bool downward)
        {
            if (downward)
                reDrawArrow(positionCalc(downward));
            else
                reDrawArrow(positionCalc(downward));
        }

        void reDrawArrow(Tuple<int, int> pos)
        {
            if (prevPos != null)
            {
                Console.SetCursorPosition(prevPos.Item1, prevPos.Item2);
                for (int i = 0; i < arrow.Length; i++)
                    Console.Write(" ");
            }

            prevPos = pos;

            Console.SetCursorPosition(pos.Item1, pos.Item2);
            Console.Write(arrow);
        }

        private Tuple<int, int> positionCalc(bool downward)
        {
            Tuple<int, int> newPos = prevPos;

            if (downward && current + 1 < range)
            {
                newPos = new Tuple<int, int>(prevPos.Item1, prevPos.Item2 + space);
                current++;
            }
            else if (!downward && current - 1 >= 0)
            {
                newPos = new Tuple<int, int>(prevPos.Item1, prevPos.Item2 - space);
                current--;
            }

            return newPos;
        }
    }
}
