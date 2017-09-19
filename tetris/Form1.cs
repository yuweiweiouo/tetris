using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.skinEngine1.SkinFile = "Vista2_color1.ssk";
        }

        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {//開始遊戲
            battle.map_initiate();//初始化地圖
            Block.score = 0;
            label4.Text = Convert.ToString(Block.score);
            label1.Text = battle.map_load();
            label2.Visible = false;
            pictureBox2.Image = global::tetris.Properties.Resources.pause;
            timer1.Enabled = true;
            KeyPreview = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && label2.Visible == true)//第一次按下enter 開始遊戲
            {
                battle.map_initiate();
                Block.score = 0;
                label4.Text = Convert.ToString(Block.score);
                label1.Text = battle.map_load();
                label2.Visible = false;
                timer1.Enabled = true;
                pictureBox2.Image = global::tetris.Properties.Resources.pause;
                KeyPreview = true;

            }

            else
            {
                string record = label4.Text;//紀錄分數
                switch (e.KeyCode)
                {//方向鍵
                    case Keys.Down: Moving.down(); break;
                    case Keys.Up: Moving.spin(); break;
                    case Keys.Left: Moving.left(); break;
                    case Keys.Right: Moving.right(); break;
                    case Keys.Space: Moving.bottom(); break;
                }
                label1.Text = Block.map_load();
                label4.Text = Convert.ToString(Block.score);
                if (record != label4.Text)
                {
                    if (Block.count != 0) Block.bouns++;//若在bonus時間範圍內 給bonus
                    else Block.bouns = 0;
                    Block.count = 2;//計時器 秒為單位
                    Block.score += Block.bouns;
                    label4.Text = Convert.ToString(Block.score);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//方塊持續掉落
            string map = label1.Text;
            Moving.down(); label1.Text = Block.map_load();
            if (map == label1.Text)
            {//判斷是否輸了
                label1.Text = "";
                label2.Text = "You Lose\nPress \"ENTER\" to start"; label2.Visible = true;
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {//倒數計時
            if (Block.count > 0) Block.count--;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {//遊戲暫停
            Block.pause ^= 1;
            if (Block.pause == 1)
            {
                pictureBox2.Image = global::tetris.Properties.Resources.start;
                timer1.Enabled = false;
                KeyPreview = false;
            }
            else
            {
                pictureBox2.Image = global::tetris.Properties.Resources.pause;
                timer1.Enabled = true;
                KeyPreview = true;
            }

        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1500;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 250;
        }

        private void crazyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 80;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("↓,←,→\n為對應移動的方向\n↑為向右旋轉方塊\nspacebar為直接落下", "I'm here to help u");
        }
    }
}
