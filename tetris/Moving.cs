using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class Moving : Block
    {
        public static void down()
        {//向下
            if (x <= 14 && down_crash != "y")
            {
                clean_block();
                x++; block();
            }
            else
            {//方塊壽命到了 換下一個方塊
                check_lineclear();
                block_produce();
            }
        }
        public static void spin()
        {//旋轉~旋轉~
            clean_block();
            spintype++;
            spintype = (spintype % 4);
            block();
        }
        public static void right()
        {//右右右右右右右右右右右
            if (right_crash != "y")
            {
                clean_block();
                y++; block();
            }
        }
        public static void left()
        {//左左左左左左左左左左左左
            if (y > 1 && left_crash != "y")
            {
                clean_block();
                y--; block();
            }
        }
        public static void bottom()
        {//直接下去6
            while (true)
            {
                if (x <= 14 && down_crash != "y")
                {
                    clean_block();
                    x++; block();
                }
                else
                {
                    Moving.check_lineclear();
                    block_produce(); break;
                }
            }
        }
        public static void check_lineclear()
        {//消行檢查ㄍ
            int count = 0;
            for (int i = 0; i < 16; i++)
            {
                for (int k = 1; k < 14; k++)
                {
                    if (map[i, k] == "▇ ") count++;
                }
                if (count == 13) lineclear(i);
                count = 0;
            }
        }
        public static void lineclear(int layer)
        {//消行囉~~
            for (; layer > 0; layer--)
            {
                for (int k = 1; k < 14; k++)
                {
                    map[layer, k] = map[layer - 1, k];
                }
            }
            score += 1;

        }
    }
}
