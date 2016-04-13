using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using DBUtility;
using System.Data;
using System.Collections;

namespace DAL
{
    public class longyuan_Bulletion
    {
        public int AddBulletion(L_BulletionInfo bulletioninfo)
        {
            StringBuilder sqlStr = new StringBuilder();

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@bulletinTitle", bulletioninfo.BulletinTitle);
            param[1] = new SqlParameter("@bulletinContent", bulletioninfo.BulletinContent);
            param[2] = new SqlParameter("@isPost", bulletioninfo.IsPost);
            param[3] = new SqlParameter("@orderNum", bulletioninfo.OrderNum);
            param[4] = new SqlParameter("@postTime", bulletioninfo.PostTime);

            sqlStr.Append("Insert Into Bulletin(");
            sqlStr.Append("bulletinTitle,bulletinContent,isPost,orderNum,postTime)");
            sqlStr.Append("values(");
            sqlStr.Append("@bulletinTitle,@bulletinContent,@isPost,@orderNum,@postTime)");

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr.ToString(), param);
        }

        public L_BulletionInfo GetBulletinInfo(int Id, Int16 InfoType)
        {
            L_BulletionInfo bulletinInfo = null;
            string sqlStr = "";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", Id);
            if (InfoType == 0)
            {
                sqlStr = "select * from Bulletin where ID=@ID and isPost=1";
            }
            else
            {
                sqlStr = "select * from Bulletin where ID=@ID";
            }

            DataSet set = SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, param);
            if (set.Tables[0].Rows.Count > 0)
            {
                DataRow drv = set.Tables[0].Rows[0];
                bulletinInfo = new L_BulletionInfo(
                        Int32.Parse(drv["ID"].ToString()),
                        drv["bulletinTitle"].ToString(),
                        drv["bulletinContent"].ToString(),
                        Int16.Parse(drv["isPost"].ToString()),
                        Int32.Parse(drv["orderNum"].ToString()),
                        DateTime.Parse(drv["postTime"].ToString())
                    );
            }

            return bulletinInfo;
        }

        public IList GetBulletinList()
        {
            IList list = new ArrayList(100);
            string sqlStr = "Select top 16 [Id], [BulletinTitle], [PostTime] From Bulletin where IsPost=1 order by OrderNum Desc,PostTime Desc";
            DataSet Set = SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);
            if (Set.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Set.Tables[0].Rows.Count; i++)
                {
                    DataRow drv = Set.Tables[0].Rows[i];
                    L_BulletionInfo bInfo = new L_BulletionInfo();
                    bInfo.ID = Int32.Parse(drv["Id"].ToString());
                    bInfo.BulletinTitle = drv["BulletinTitle"].ToString();
                    bInfo.PostTime = DateTime.Parse(drv["PostTime"].ToString());
                    list.Add(bInfo);
                }

            }
            return list;
        }

        public int updateBulletion(L_BulletionInfo bulletin)
        {
            StringBuilder sqlStr = new StringBuilder();
            SqlParameter[] param = new SqlParameter[6];
          
            param[0] = new SqlParameter("@bulletinTitle", bulletin.BulletinTitle);
            param[1] = new SqlParameter("@bulletinContent", bulletin.BulletinContent);
            param[2] = new SqlParameter("@isPost", bulletin.IsPost);
            param[3] = new SqlParameter("@orderNum", bulletin.OrderNum);
            param[4] = new SqlParameter("@postTime", bulletin.PostTime); 
            param[5] = new SqlParameter("@ID", bulletin.ID);

            sqlStr.Append("Update Bulletin Set ");
            sqlStr.Append(" bulletinTitle=@bulletinTitle,bulletinContent=@bulletinContent,orderNum=@orderNum,postTime=@postTime ");
            sqlStr.Append(" where ID=@ID");

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr.ToString(), param);
        }

      
    }
}
