using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class longyuan_AcceptAddrInfo
    {
        longyuan_AcceptAddr acceptaddr = new longyuan_AcceptAddr();
       
        public int InsertAcceptAddr(L_AcceptAddrInfo acceptinfo)
        {
            return acceptaddr.UpdateAcceptAddr(acceptinfo);
        }

        public L_AcceptAddrInfo GetBindUpdateAcceptAddr(int id, int userID)
        {
            return acceptaddr.GetBindUpdateAcceptAddr(id, userID);
        }

        public int UpdateAcceptAddr(L_AcceptAddrInfo acceptinfo)
        {
            return acceptaddr.UpdateAcceptAddr(acceptinfo);
        }
    }
}
