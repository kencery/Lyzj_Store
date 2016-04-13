using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

public partial class Tool_CheckInage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string validateNum = CreateRandomNum(4); //生成6位随机字符串
            CreateImage(validateNum);
            Session["validateNum"] = validateNum;
        }
    }

    /// <summary>
    /// 生成随机数
    /// </summary>
    /// <param name="numCount">随机生成的长度的字符</param>
    /// <returns>返回生成的随机数</returns>
    private string CreateRandomNum(int numCount)
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        string[] allCharArray = allChar.Split(',');  //拆分成数组
        string randomNum = "";
        int temp = -1;  //记录上次随机数的数值，尽量避免产生几个相同的随机数
        Random rand = new Random();
        for (int i = 0; i < numCount; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(35);
            if (temp == t)
            {
                return CreateRandomNum(numCount);
            }
            temp = t;
            randomNum += allCharArray[t];
        }
        return randomNum;
    }

    /// <summary>
    /// 生成图片
    /// </summary>
    /// <param name="validateNum">产生的随记字符串</param>
    private void CreateImage(string validateNum)
    {
        if (validateNum == null || validateNum.Trim() == string.Empty)
        {
            return;
        }
        //生成Bitmap图像
        Bitmap image = new Bitmap(validateNum.Length * 12 + 10, 22);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随记生成器
            Random random = new Random();
            //清空图片背景色
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 40; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.GreenYellow), x1, x2, y1, y2);
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(validateNum, font, brush, 2, 2);
            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线
            g.DrawRectangle(new Pen(Color.HotPink), 0, 0, image.Width - 1, image.Height - 1);
            MemoryStream ms = new MemoryStream();
            //将图像保存到指定的流
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
}
