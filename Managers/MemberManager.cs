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

        /// <summary>
        /// Adds test members at the start of the program
        /// </summary>
        internal void AddMembersOnStart()
        {

            for(int i = 0; i < 25; i++)
            {
                members.Add(new Member(startID, "Member" + memberNameID.ToString()));
                startID++;
                memberNameID++;
            }
        }

        /// <summary>
        /// Adds a new member to the member list
        /// </summary>
        /// <param name="name"></param>
        internal void AddMember(string name)
        {
            members.Add(new Member(startID, "Member" + memberNameID.ToString()));
            startID++;
            memberNameID++;
        }

        /// <summary>
        /// Removes a member from the member list
        /// </summary>
        /// <param name="index"></param>
        internal void RemoveMember(int index) 
        { 
                members.RemoveAt(index);
        }

        /// <summary>
        /// Returns the number of members in the members list
        /// </summary>
        /// <returns></returns>
        internal int NumberOfMembers()
        {
            return members.Count;
        }

        /// <summary>
        /// Gets a specific member at the index position of the argument
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
