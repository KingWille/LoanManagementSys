using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSys.Managers
{
    internal class MemberManager
    {
        private List<Member> members;
        int startID = 100;
        int memberNameID = 0;

        private void AddMember(string name)
        {
            members.Add(new Member(startID, "Member" + memberNameID.ToString()));
            startID++;
            memberNameID++;
        }

        private void RemoveMember(int index) 
        { 
            try
            {
                members.RemoveAt(index);
            }
            catch
            {

            }
        }

        private Member GetMember(int index)
        {
            try
            {
                return members[index]; 
            }
            catch
            {
                return null;
            }
        }
    }
}
