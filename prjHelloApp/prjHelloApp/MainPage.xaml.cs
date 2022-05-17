using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace prjHelloApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
            
        }
        Random rd = new Random();
        public Color colorNum(int n)
        {
            if (n == 0)
                return Color.Red;
            else if (n == 1)
                return Color.Orange;
            else if (n == 2)
                return Color.Yellow;
            else
                return Color.Green;
        }

        public void ChangeColor(object sender, EventArgs e)
        {
            var list = Enumerable.Range(0,4).OrderBy(c=>rd.Next()).ToList();
            l1.BackgroundColor = colorNum(list[0]);
            l2.BackgroundColor = colorNum(list[1]);
            l3.BackgroundColor = colorNum(list[2]);
            l4.BackgroundColor = colorNum(list[3]);
        }

        public string wordNum(int n)
        {
            if (n == 0)
                return "Red";
            else if (n == 1)
                return "Orange";
            else if (n == 2)
                return "Yellow";
            else
                return "Green";
        }
        public void ChangeWord(object sender, EventArgs e)
        {
            var list = Enumerable.Range(0, 4).OrderBy(c => rd.Next()).ToList();
            for(int i =0;i<list.Count;i++)
            {
                if (list[i] == i)
                {
                    int temp = list[i];
                    if (i != list.Count - 1)
                    {
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                    else
                    {
                        list[i] = list[0];
                        list[0] = temp;
                    }
                }
            }
            l1.Text = wordNum(list[0]);
            l2.Text = wordNum(list[1]);
            l3.Text = wordNum(list[2]);
            l4.Text = wordNum(list[3]);
        }
        
        List<Label> listLb = new List<Label>();
        List<int> set = new List<int>();
        public void lettoryNumber(object sender, EventArgs e)
        {
            listLb.Clear();
            set.Clear();
            stackLettory.Children.Clear();
            for(int i = 0; i < 6; i++)
            {
                int temp=rd.Next(1,47);
                if (set.Contains(temp))
                    i--;
                else
                {   set.Add(temp);
                    listLb.Add(new Label());
                    listLb[i].Text = set[i] <10? $"0{set[i]}":$"{set[i]}";
                    listLb[i].FontSize = 20;
                    stackLettory.Children.Add(listLb[i]);
                }
            }
        }

        public void sortB(object sender, EventArgs e)
        {
            if (listLb.Count==0) return;

            for (int i = 0; i < 6; i++)
            {
                for(int j = i + 1; j < 6; j++)
                {
                    if (set[i] > set[j])
                    {
                        int temp = set[i];
                        set[i] = set[j];
                        set[j] = temp;
                    }
                }
                listLb[i].Text = set[i] < 10 ? $"0{set[i]}" : $"{set[i]}";
            }
        }
    }
}
