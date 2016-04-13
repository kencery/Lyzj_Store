using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Collections;

namespace BLL
{
    public class longyuan_BulletionInfo
    {
        private longyuan_Bulletion bulletion = new longyuan_Bulletion();

        public int AddBulletion(L_BulletionInfo bulletioninfo)
        {
            return bulletion.AddBulletion(bulletioninfo);
        }

        public L_BulletionInfo GetBulletinInfo(int Id, Int16 InfoType)
        {
            return bulletion.GetBulletinInfo(Id, InfoType);
        }

        public IList GetBulletinList()
        {
            return bulletion.GetBulletinList();
        }

        public int updateBulletion(L_BulletionInfo bulletin)
        {
            return bulletion.updateBulletion(bulletin);
        }
    }

}
