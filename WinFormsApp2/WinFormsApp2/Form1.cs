namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Drawing.Graphics desen;
        System.Drawing.Pen creion_negru;
        System.Drawing.SolidBrush pensula_rosie;
        System.Drawing.SolidBrush pensula_verde;
        System.Random n;

        struct tranz_bursa
        {
            public int data;
            public int val_min;
            public int val_max;
            public int val_desch;
            public int val_inch;
            public int x;

            public tranz_bursa(int data, int val_min, int val_max, int val_desch, int val_inch, int x)
            {
                this.data = data;
                this.val_min = val_min;
                this.val_max = val_max;
                this.val_desch = val_desch;
                this.val_inch = val_inch;
                this.x = x;
            }
        }

        tranz_bursa[] tb = new tranz_bursa[8];

        int x = 100;
        int y = 100;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            desen = this.CreateGraphics();
            creion_negru = new System.Drawing.Pen(System.Drawing.Color.Black);
            pensula_rosie = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            pensula_verde = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            n = new System.Random();

            for (int i = 0; i <= 7; i++)
            {
                tb[i] = new tranz_bursa(n.Next(100, 300), 10, 10, 10, 10, x);

                if (i == 0)
                {
                    desen.FillRectangle(pensula_verde, x, tb[i].data, 10, 20);
                }
                else
                {
                    if (tb[i - 1].data < tb[i].data)
                    {
                        desen.FillRectangle(pensula_rosie, x, tb[i].data, 10, 20);
                    }
                    else
                    {
                        desen.FillRectangle(pensula_verde, x, tb[i].data, 10, 20);
                    }
                }

                x += 100;
            }

            x = 100;

            for (int i = 0; i <= 5; i++)
            {
                desen.DrawLine(creion_negru, tb[i].x, tb[i].data + 10, tb[i + 1].x, tb[i + 1].data + 10);
            }
        }
    }
}