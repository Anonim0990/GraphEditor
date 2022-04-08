using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;


namespace lab
{
    public partial class Form1 : Form
    {
        private readonly ComponentResourceManager resources;

        private Bitmap NewMap;
        
        private Pen pen;
        private SolidBrush b;
        private Font f;

        private int Can = 0;

        private Pen penSelect;

        private Pen penLine;
        private Pen penNoLine;

        private Color ThisColor;
        private const float W = 2.5F;
        private (int x,int y,Color k , int index)choosenOne=(-1,-1,Color.White,0);
        private (int x, int y, Color k, int index) PrevchoosenOne = (-1, -1, Color.White,0);
        private (int x, int y) Last = (-1, -1);

        private const int R = 12;
        private const int fontSize = 10;
        private List<(int x, int y, Color K)> V = new List<(int x, int y, Color K)>();
        private List<(int x, int y, Color K)> newV = new List<(int x, int y, Color K)>();
        private int counter = 1;

        private List<(int x1, int y1, int x2, int y2)> E = new List<(int x1, int y1, int x2, int y2)>();
        private List<(int x1, int y1, int x2, int y2)> newE = new List<(int x1, int y1, int x2, int y2)>();

        private StringFormat drawFormat = new StringFormat();
       
        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            InitializeComponent();
            NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
            Map.Image = NewMap;
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;
            ThisColor = Color.Black;

            penSelect = new Pen(Color.White, W);
            penSelect.DashPattern = new float[] { 1, 1 };
            f = new Font("TimesNewRoman", fontSize);

            penLine = new Pen(Color.Black, W);
            penNoLine = new Pen(Color.White, W);
            resources = new ComponentResourceManager(typeof(Form1));
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int tmp1 = 1;
                if (choosenOne.x != -1)
                {
                    foreach (var v in V)
                    {
                        if (v.x == choosenOne.x && v.y == choosenOne.y) continue;
                        if ((e.X - v.x) * (e.X - v.x) + (e.Y - v.y) * (e.Y - v.y) < R * R)
                        {
                            
                            if (!E.Contains((choosenOne.x, choosenOne.y, v.x, v.y)) || !E.Contains((v.x, v.y, choosenOne.x, choosenOne.y)))
                            {
                                E.Add((choosenOne.x, choosenOne.y, v.x, v.y));
                                using (Graphics g = Graphics.FromImage(NewMap))
                                {
                                    PointF point1 = new PointF(v.x, v.y);
                                    PointF point2 = new PointF(choosenOne.x, choosenOne.y);
                                    g.DrawLine(penLine, point1, point2);
                                }
                                tmp1 = 0;
                                DrawE();
                                DrawV();
                            }
                            break;
                        }
                    }
                }
                if (tmp1 == 1) 
                { 
                    int flag = 1;
                    foreach (var v in V)
                    {
                        if ((e.X - v.x) * (e.X -v.x) + (e.Y - v.y) * (e.Y - v.y) < 4 * R * R)
                        {
                        
                            flag =0;
                            break;
                        }
                    }
                    if (flag == 1)
                    {
                        V.Add((e.X, e.Y, ThisColor));
                        using (Graphics g = Graphics.FromImage(NewMap))
                        {
                            pen = new Pen(ThisColor, W);
                            b = new SolidBrush(ThisColor);


                            g.DrawEllipse(pen, e.X - R, e.Y - R, R * 2, R * 2);
                            g.FillEllipse(Brushes.White, e.X - R+W-1, e.Y - R+W-1, R * 2-W, R * 2-W);
                            g.DrawString((counter++).ToString(), f, b, e.X, e.Y, drawFormat);
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                int flag = 1;
                int i = 1;
                foreach (var v in V)
                {
                    if ((e.X - v.x) * (e.X - v.x) + (e.Y - v.y) * (e.Y - v.y) <  R * R)
                    {
                        flag = 0;
                        PrevchoosenOne = choosenOne;
                        choosenOne = (v.x, v.y,v.K,i);
                        break;
                    }
                    i++;
                }
                if ((flag == 1 && choosenOne.x != -1) || PrevchoosenOne==choosenOne ) 
                {
                    using (Graphics g = Graphics.FromImage(NewMap))
                    {
                        pen = new Pen(choosenOne.k, W);                        
                        g.DrawEllipse(pen, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                        //g.FillEllipse(Brushes.White, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                    }
                    choosenOne = (-1, -1,Color.White,0);
                }
                else if ( flag == 0 )
                {
                    using (Graphics g = Graphics.FromImage(NewMap))
                    {
                        if (PrevchoosenOne.x != -1)
                        {
                            pen = new Pen(PrevchoosenOne.k, W);
                            g.DrawEllipse(pen, PrevchoosenOne.x - R, PrevchoosenOne.y - R, R * 2, R * 2);
                            //g.FillEllipse(Brushes.White, PrevchoosenOne.x - R, PrevchoosenOne.y - R, R * 2, R * 2);
                        }
                        g.DrawEllipse(penSelect, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                        //g.FillEllipse(Brushes.White, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                    }
                }
            }
            
            Map.Refresh();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            counter = 1;
            NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
            Map.Image = NewMap;
            DrawE();
            DrawV();
        }
        
        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ThisColor = colorDialog.Color;
                kolorek.BackColor = ThisColor;
                choosenOne.k = ThisColor;
                for(int i = 0; i < V.Count; i++)
                {
                   if( V[i].x==choosenOne.x && V[i].y == choosenOne.y)
                    {
                        V[i] = (choosenOne.x,choosenOne.y,ThisColor);
                        break;
                    }
                }
                DrawV();
            }
        }


        private void DrawV()
        {
            counter = 1;
            foreach (var v in V)
            {
                using (Graphics g = Graphics.FromImage(NewMap))
                {
                    pen = new Pen(v.K, W);
                    b = new SolidBrush(v.K);
                    

                    g.DrawEllipse(pen, v.x - R, v.y - R, R * 2, R * 2);
                    g.FillEllipse(Brushes.White, v.x - R+W-1, v.y - R+W-1, R * 2 - W , R * 2 - W);
                    g.DrawString((counter++).ToString(), f, b, v.x, v.y, drawFormat);
                }
            }
            if (choosenOne.x != -1)
            {
                using (Graphics g = Graphics.FromImage(NewMap))
                {
                    pen = new Pen(choosenOne.k, W);
                    b = new SolidBrush(choosenOne.k);
                    g.DrawEllipse(pen, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                    g.DrawEllipse(penSelect, choosenOne.x - R, choosenOne.y - R, R * 2, R * 2);
                    g.FillEllipse(Brushes.White, choosenOne.x - R + W - 1, choosenOne.y - R + W - 1, R * 2-W, R * 2-W);
                    g.DrawString((choosenOne.index).ToString(), f, b, choosenOne.x, choosenOne.y, drawFormat);
                }
            }
            Map.Refresh();
        }
        
        private void DrawE()
        {
            foreach (var e in E)
            {
                using (Graphics g = Graphics.FromImage(NewMap))
                {
                    PointF point1 = new PointF(e.x1, e.y1);
                    PointF point2 = new PointF(e.x2, e.y2);
                    g.DrawLine(penLine, point1, point2);
                }
            }
        }
        
        private void buttonDeleteV_Click(object sender, EventArgs e)
        {
            if (choosenOne.x != -1)
            {
                for(int i = 0; i < E.Count; i++)
                {
                    if((E[i].x1==choosenOne.x && E[i].y1==choosenOne.y)|| (E[i].x2 == choosenOne.x && E[i].y2 == choosenOne.y))
                    {
                        using (Graphics g = Graphics.FromImage(NewMap))
                        {
                            PointF point1 = new PointF(E[i].x1, E[i].y1);
                            PointF point2 = new PointF(E[i].x2, E[i].y2);
                            g.DrawLine(penNoLine, point1, point2);
                        }
                        E.Remove(E[i]);
                        i = i-1;
                    }
                }
                V.Remove((choosenOne.x, choosenOne.y, choosenOne.k));
                choosenOne = (-1, -1, Color.White, 0);
                NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
                Map.Image = NewMap;
                Map.Refresh();
                DrawE();
                DrawV();
            }
        }
        
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {

            V.Clear();
            E.Clear();
            counter = 1;
            choosenOne = (-1, -1, Color.White, 0);
            NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
            Map.Image = NewMap;
            Map.Refresh();
        }
        
        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (choosenOne.x != -1)
                {
                    Can = 1;
                    Last = (e.X, e.Y);
                }
            }
        }
        
        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                int xx = choosenOne.x + e.X - Last.x;
                int yy = choosenOne.y + e.Y - Last.y;

                NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);

                if (xx < 0) xx = 0;
                if (yy < 0) yy = 0;
                if (xx > Map.Size.Width) xx = Map.Size.Width;
                if (yy > Map.Size.Height) yy = Map.Size.Height;

                if (Can == 1)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (V[i].x == choosenOne.x && V[i].y == choosenOne.y)
                        {
                            V[i] = (xx, yy, choosenOne.k);
                            break;
                        }
                    }
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].x1 == choosenOne.x && E[i].y1 == choosenOne.y)
                        {
                            using (Graphics g = Graphics.FromImage(NewMap))
                            {
                                PointF point1 = new PointF(E[i].x1, E[i].y1);
                                PointF point2 = new PointF(E[i].x2, E[i].y2);
                                g.DrawLine(penNoLine, point1, point2);
                            }
                            E[i] = ((E[i].x2, E[i].y2, xx, yy));
                            
                        }
                        else if (E[i].x2 == choosenOne.x && E[i].y2 == choosenOne.y)
                        {
                            using (Graphics g = Graphics.FromImage(NewMap))
                            {
                                PointF point1 = new PointF(E[i].x1, E[i].y1);
                                PointF point2 = new PointF(E[i].x2, E[i].y2);
                                g.DrawLine(penNoLine, point1, point2);
                            }
                            E[i] = ((E[i].x1, E[i].y1, xx, yy));
                           
                        }
                    }
                    choosenOne = (xx, yy, choosenOne.k, choosenOne.index);
                    Last = (e.X, e.Y);
                    NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
                    Map.Image = NewMap;
                    DrawE();
                    DrawV();
                }
            }
        }

        
        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Can = 0;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Graph files (*.graph) | *.graph";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter stream = new StreamWriter(dialog.OpenFile()))
                    {
                        for (int i = 0; i < V.Count; ++i)
                        {
                            stream.WriteLine($"{V[i].x},{V[i].y}," +$"{V[i].K.ToArgb()}");                            
                        }
                        stream.WriteLine(",");
                        for (int i = 0; i < E.Count; ++i)
                        {
                            stream.WriteLine($"{E[i].x1},{E[i].y1}," + $"{E[i].x2},{E[i].y2}");
                        }
                    }
                    MessageBox.Show("Graph Saved");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Graph files (*.graph) | *.graph";
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader stream = new StreamReader(dialog.OpenFile()))
                    {

                        try
                        {
                            Loadd(stream);
                            V.Clear();
                            E.Clear();
                            for(int i = 0; i < newV.Count; i++)
                            {
                                V.Add(newV[i]);
                            }
                            for (int i = 0; i < newE.Count; i++)
                            {
                                E.Add(newE[i]);
                            }
                            newV.Clear();
                            newE.Clear();
                            counter = 1;
                            choosenOne = (-1, -1, Color.White, 0);
                        }
                        catch
                        {
                            MessageBox.Show("ErrorLoadMessage");
                            return;
                        }
                    }
                    
                    
                    NewMap = new Bitmap(Map.Size.Width, Map.Size.Height);
                    Map.Image = NewMap;
                    DrawE();
                    DrawV();

                    MessageBox.Show("Graph Loaded");
                }
            }
        }

        private void Loadd(StreamReader stream)
        {
            int flag = 0;
            newV.Clear();
            newE.Clear();
            while (!stream.EndOfStream)
            {
                int[] VV = null;
                int[] EE = null;

                if (flag == 0)
                { 
                    VV = Array.ConvertAll(stream.ReadLine().Split(','), int.Parse);
                    if (VV.Length != 3)throw new ArgumentException();
                }
                if (flag == 1)
                {
                    EE = Array.ConvertAll(stream.ReadLine().Split(','), int.Parse);
                    if (EE.Length != 4) throw new ArgumentException();
                }
                if (stream.Peek() == ',')
                {
                    stream.ReadLine();
                    flag = 1;
                }
                
                if (VV != null) 
                {
                    for(int i =0 ;i<VV.Length; i = i + 3)
                    {
                        newV.Add((VV[i], VV[i + 1], Color.FromArgb(VV[i + 2])));
                    }
                }
                if (EE != null)
                {
                    for (int i = 0; i < EE.Length; i = i + 4)
                    {
                        newE.Add((EE[i], EE[i + 1], EE[i + 2], EE[i + 3]));
                    }
                }

            }
        }

        private void buttonPl_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            var Localization = this.Location;
            var Size = this.Size;
            resources.ApplyResources(this, "$this");
            Change(resources, this.Controls);
            this.Location = Localization;
            this.Size = Size;
        }

        private void buttonEng_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            var Localization = this.Location;
            var Size = this.Size;
            resources.ApplyResources(this, "$this");
            Change(resources, this.Controls);
            this.Location = Localization;
            this.Size = Size;
        }

        private void Change(ComponentResourceManager resources, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                var Localization = control.Location;
                var Size = control.Size;
                
                if (control.GetType() != typeof(TableLayoutPanel)) resources.ApplyResources(control, control.Name);
                Change(resources, control.Controls);
                control.Location = Localization;
                control.Size = Size;
            }
        }
    }
}
