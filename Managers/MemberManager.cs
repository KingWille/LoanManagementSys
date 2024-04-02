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

        public MemberManager()
        {
            members = new List<Member>();
        }
        internal void AddMembersOnStart()
        {

            for(int i = 0; i < 25; i++)
            {
                members.Add(new Member(startID, "Member" + memberNameID.ToString()));
                startID++;
                memberNameID++;
            }
        }
        internal void AddMember(string name)
        {
            members.Add(new Member(startID, "Member" + memberNameID.ToString()));
            startID++;
            memberNameID++;
        }

        internal void RemoveMember(int index) 
        { 
            try
            {
                members.RemoveAt(index);
            }
            catch
            {

            }
        }

        internal int NumberOfMembers()
        {
            return members.Count;
        }

        internal Member GetMember(int index)
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
