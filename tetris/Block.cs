using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class Block : battle
    {
        public static int spintype = 0, blocktype = 1;
        public static string input = "";
        public static int x, y;
        public static string down_crash = "", left_crash = "", right_crash = "";
        public static int score, count = 0, bouns, pause = 0;
        public static void block_produce()
        {
            x = 2; y = 6;//原始座標
            spintype = 0; blocktype = 1;
            down_crash = "n";//碰撞偵測 參考csma/cd的原理
            Random r = new Random();
            input = "▇ ";
            blocktype = r.Next(1, 8);
            switch (blocktype)
            {//7 kinds of possibilities
                case 1: blocktype = 1; L_set(); break;
                case 2: blocktype = 2; J_set(); break;
                case 3: blocktype = 3; o_set(); break;
                case 4: blocktype = 4; s_set(); break;
                case 5: blocktype = 5; z_set(); break;
                case 6: blocktype = 6; t_set(); break;
                case 7: blocktype = 7; l_set(); break;
            }
            map_load();
        }
        public static void block()
        {//持續reload方塊
            input = "▇ ";
            switch (blocktype)
            {
                case 1: L_set(); break;
                case 2: J_set(); break;
                case 3: o_set(); break;
                case 4: s_set(); break;
                case 5: z_set(); break;
                case 6: t_set(); break;
                case 7: l_set(); break;
            }
            map_load();
        }
        public static void clean_block()
        {//持續清除上一秒的方塊
            input = "　 ";
            switch (blocktype)
            {
                case 1: L_set(); break;
                case 2: J_set(); break;
                case 3: o_set(); break;
                case 4: s_set(); break;
                case 5: z_set(); break;
                case 6: t_set(); break;
                case 7: l_set(); break;
            }
            map_load();
        }
        //下面為7種方塊產生及對應碰撞偵測
        //各方塊有不同旋轉的狀態
        //依照spintype 判斷當前旋轉的狀態
        public static void L_set()
        {
            try
            {
                switch (spintype)
                {
                    case 0:
                        battle.map[x - 2, y] = input;
                        battle.map[x - 1, y] = input;
                        battle.map[x, y] = input; battle.map[x, y + 1] = input;
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ ") down_crash = "y";
                        if (y + 2 < 14)
                        {
                            if (map[x - 2, y + 1] == "▇ " || map[x - 1, y + 1] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y - 1] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 1:
                        if (y + 2 < 14)
                        {
                            battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input; battle.map[x - 1, y + 2] = input;
                            battle.map[x, y] = input;
                            if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x, y + 1] == "▇ " || map[x, y + 2] == "▇ ") down_crash = "y";
                            if (y + 3 < 14)
                            {
                                if (map[x - 1, y + 3] == "▇ " || map[x, y + 1] == "▇ ") right_crash = "y";
                                else right_crash = "";
                            }
                            else right_crash = "y";
                            if (map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                            else left_crash = "n";
                        }
                        break;
                    case 2:
                        battle.map[x - 2, y] = input; battle.map[x - 2, y + 1] = input;
                        battle.map[x - 1, y + 1] = input;
                        battle.map[x, y + 1] = input;
                        if (x + 1 < 16) if (map[x - 1, y] == "▇ " || map[x + 1, y + 1] == "▇ ") down_crash = "y";
                        if (y + 2 < 14)
                        {
                            if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 2] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y - 1] == "▇ " || map[x - 1, y] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 3:
                        battle.map[x - 1, y + 2] = input;
                        battle.map[x, y] = input; battle.map[x, y + 1] = input; battle.map[x, y + 2] = input;
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ " || map[x + 1, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 1, y + 3] == "▇ " || map[x, y + 3] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 1, y + 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                }
            }
            catch (Exception e) { }
        }

        public static void J_set()
        {
            try
            {
                switch (spintype)
                {
                    case 0:
                        battle.map[x - 2, y + 1] = input;
                        battle.map[x - 1, y + 1] = input;
                        battle.map[x, y] = input; battle.map[x, y + 1] = input;
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ ") down_crash = "y";
                        if (y + 2 < 14)
                        {
                            if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 2] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y] == "▇ " || map[x - 1, y] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 1:
                        if (y + 2 < 14)
                        {
                            battle.map[x - 1, y] = input;
                            battle.map[x, y] = input; battle.map[x, y + 1] = input; battle.map[x, y + 2] = input;
                        }
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ " || map[x + 1, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 1, y + 1] == "▇ " || map[x, y + 3] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 2:
                        battle.map[x - 2, y] = input; battle.map[x - 2, y + 1] = input;
                        battle.map[x - 1, y] = input;
                        battle.map[x, y] = input;
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x - 1, y + 1] == "▇ ") down_crash = "y";
                        if (y + 2 < 14)
                        {
                            if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 1] == "▇ " || map[x, y + 1] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y - 1] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 3:
                        battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input; battle.map[x - 1, y + 2] = input;
                        battle.map[x, y + 2] = input;
                        if (x + 1 < 16) if (map[x, y] == "▇ " || map[x, y + 1] == "▇ " || map[x + 1, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 1, y + 3] == "▇ " || map[x, y + 3] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 1, y - 1] == "▇ " || map[x, y + 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                }
            }
            catch (Exception e) { }
        }
        public static void o_set()
        {
            battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input;
            battle.map[x, y] = input; battle.map[x, y + 1] = input;
            if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ ") down_crash = "y";
            if (y + 2 < 14)
            {
                if (map[x - 1, y + 2] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                else right_crash = "";
            }
            else right_crash = "y";
            if (map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
            else left_crash = "n";
        }
        public static void z_set()
        {
            try
            {
                if (spintype % 2 == 0)
                {
                    battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input;
                    battle.map[x, y + 1] = input; battle.map[x, y + 2] = input;
                    if (x + 1 < 16) if (map[x, y] == "▇ " || map[x + 1, y + 1] == "▇ " || map[x + 1, y + 2] == "▇ ") down_crash = "y";
                    if (y + 3 < 14)
                    {
                        if (map[x - 1, y + 2] == "▇ " || map[x, y + 3] == "▇ ") right_crash = "y";
                        else right_crash = "";
                    }
                    else right_crash = "y";
                    if (map[x - 1, y - 1] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                    else left_crash = "n";

                }
                if (spintype % 2 == 1)
                {
                    battle.map[x - 2, y + 1] = input;
                    battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input;
                    battle.map[x, y] = input;
                    if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x, y + 1] == "▇ ") down_crash = "y";
                    if (y + 2 < 14)
                    {
                        if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 2] == "▇ " || map[x, y + 1] == "▇ ") right_crash = "y";
                        else right_crash = "";
                    }
                    else right_crash = "y";
                    if (map[x - 2, y] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                    else left_crash = "n";

                }
            }
            catch (Exception e) { }
        }
        public static void s_set()
        {
            try
            {
                if (spintype % 2 == 0)
                {
                    battle.map[x - 1, y + 1] = input; battle.map[x - 1, y + 2] = input;
                    battle.map[x, y] = input; battle.map[x, y + 1] = input;
                    if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ " || map[x, y + 2] == "▇ ") down_crash = "y";
                    if (y + 3 < 14)
                    {
                        if (map[x - 1, y + 3] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                        else right_crash = "";
                    }
                    else right_crash = "y";
                    if (map[x - 1, y] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                    else left_crash = "n";
                }
                if (spintype % 2 == 1)
                {
                    battle.map[x - 2, y] = input;
                    battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input;
                    battle.map[x, y + 1] = input;
                    if (x + 1 < 16) if (map[x, y] == "▇ " || map[x + 1, y + 1] == "▇ ") down_crash = "y";
                    if (y + 2 < 14)
                    {
                        if (map[x - 2, y + 1] == "▇ " || map[x - 1, y + 2] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                        else right_crash = "";
                    }
                    else right_crash = "y";
                    if (map[x - 2, y - 1] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                    else left_crash = "n";
                }
            }
            catch (Exception e) { }
        }
        public static void t_set()
        {
            try
            {
                switch (spintype)
                {
                    case 0:
                        battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input; battle.map[x - 1, y + 2] = input;
                        battle.map[x, y + 1] = input;
                        if (x + 1 < 16)
                            if (map[x + 1, y + 1] == "▇ " || map[x, y] == "▇ " || map[x, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 1, y + 3] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 1, y - 1] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                    case 1:
                        battle.map[x - 2, y + 1] = input;
                        battle.map[x - 1, y] = input; battle.map[x - 1, y + 1] = input;
                        battle.map[x, y + 1] = input;
                        if (x + 1 < 16)
                            if (map[x + 1, y + 1] == "▇ " || map[x, y] == "▇ ") down_crash = "y";
                        if (y + 2 < 14)
                        {
                            if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 2] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;

                    case 2:
                        battle.map[x - 1, y + 1] = input;
                        battle.map[x, y] = input; battle.map[x, y + 1] = input; battle.map[x, y + 2] = input;
                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ " || map[x + 1, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 1, y + 2] == "▇ " || map[x, y + 3] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 1, y] == "▇ " || map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";

                        break;
                    case 3:
                        battle.map[x - 2, y + 1] = input;
                        battle.map[x - 1, y + 1] = input; battle.map[x - 1, y + 2] = input;
                        battle.map[x, y + 1] = input;
                        if (x + 1 < 16) if (map[x + 1, y + 1] == "▇ " || map[x, y + 2] == "▇ ") down_crash = "y";
                        if (y + 3 < 14)
                        {
                            if (map[x - 2, y + 2] == "▇ " || map[x - 1, y + 3] == "▇ " || map[x, y + 2] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x - 2, y] == "▇ " || map[x - 1, y] == "▇ " || map[x, y] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                        break;
                }
            }
            catch (Exception e) { }
        }
        public static void l_set()
        {
            try
            {
                if (spintype % 2 == 0)
                {
                    battle.map[x - 2, y] = input;
                    battle.map[x - 1, y] = input;
                    battle.map[x, y] = input;
                    battle.map[x + 1, y] = input;

                    if (x + 2 < 16)
                    {
                        if (map[x + 2, y] == "▇ ") down_crash = "y";
                    }
                    else down_crash = "y";
                    if (y + 1 < 14)
                    {
                        if (map[x - 2, y + 1] == "▇ " || map[x - 1, y + 1] == "▇ " || map[x, y + 1] == "▇ " || map[x + 1, y + 1] == "▇ ") right_crash = "y";
                        else right_crash = "";
                    }
                    else right_crash = "y";
                    if (map[x - 2, y - 1] == "▇ " || map[x - 1, y - 1] == "▇ " || map[x, y - 1] == "▇ " || map[x + 1, y - 1] == "▇ ") left_crash = "y";
                    else left_crash = "n";
                }
                if (spintype % 2 == 1)
                {
                    if (y + 3 < 14)
                    {
                        battle.map[x, y] = input; battle.map[x, y + 1] = input;
                        battle.map[x, y + 2] = input; battle.map[x, y + 3] = input;

                        if (x + 1 < 16) if (map[x + 1, y] == "▇ " || map[x + 1, y + 1] == "▇ "
                                || map[x + 1, y + 2] == "▇ " || map[x + 1, y + 3] == "▇ ") down_crash = "y";
                        if (y + 4 < 14)
                        {
                            if (map[x, y + 4] == "▇ ") right_crash = "y";
                            else right_crash = "";
                        }
                        else right_crash = "y";
                        if (map[x, y - 1] == "▇ ") left_crash = "y";
                        else left_crash = "n";
                    }

                }
            }
            catch (Exception e) { }
        }
    }
}
