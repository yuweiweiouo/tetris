using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class battle
    {
        public static string[,] map = new string[16, 14];//建立地圖容器
        public static void map_initiate()//初始化地圖
        {
            Block.score = 0;//分數初始化
            battle a = new battle();
            Block.x = 3;Block.y = 6;//初始位置
            for (int i = 0; i < 16; i++)
            {
                map[i, 0] = " ";
            }
            for (int i = 0; i < 16; i++)
            {
                for (int k = 1; k < 14; k++)
                {
                    map[i, k] = "　 ";
                }
            }
            Block.block_produce();
        }
        public static string map_load()
        {//載入地圖
            string print = "";
            for (int i = 0; i < 16; i++)
            {
                for (int k = 0; k < 14; k++)
                {
                    print += map[i, k];
                }
                print += "\n";
            }
            return print;
        }
    }
}
