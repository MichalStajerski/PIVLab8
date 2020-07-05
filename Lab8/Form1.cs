using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        List<Control> humans = new List<Control>();
        List<Control> soldiers = new List<Control>();
        List<Control> zombies = new List<Control>();
        List<Control> players = new List<Control>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            var random = new Random();

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text))
            {
                return;
            }


            FillList(int.Parse(textBox1.Text), humans, players, Playertype.Human, panel1,random);
            FillList(int.Parse(textBox1.Text), soldiers, players, Playertype.Soldier, panel1,random);
            FillList(int.Parse(textBox1.Text), zombies, players, Playertype.Zombie, panel1,random);

            panel1.Invalidate();

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;

            button1.Enabled = true;
            button2.Visible = false;
        }


        private void FillList(int amount, List<Control> controls,
            List<Control> allControls,Playertype playerType, Panel board,Random random)
        {
            
            for(int i = 0; i < amount; i++)
            {
                PictureBox newPlayer = new PictureBox()
                {
                    Height = 20,
                    Width = 20,
                    Location = new Point(random.Next(0, 240), random.Next(0, 240))
                    
                };

                switch (playerType)
                {
                    case Playertype.Human:
                        newPlayer.Image = Image.FromFile("resources/human.png");
                        break;

                    case Playertype.Soldier:
                        newPlayer.Image = Image.FromFile("resources/soldier.png");
                        break;

                    case Playertype.Zombie:
                        newPlayer.Image = Image.FromFile("resources/zombie.png");
                        break;
                }

                newPlayer.Invalidate();

                controls.Add(newPlayer);
                allControls.Add(newPlayer);
                board.Controls.Add(newPlayer);
            }
        }

        public enum Playertype
        {
            Human,
            Soldier,
            Zombie
        }
      
    }
}
