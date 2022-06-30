using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_ROM
{
    public class SearchResult
    {
        int diskID, ownerID, programID, diskProgramID;
        string diskDescription, ownerSecondName, ownerFirstName, ownerMiddleName, programName;
        public SearchResult(){

        }
        public int DiskID
        {
            get { return diskID; }
            set { diskID = value; }
        }
        public int OwnerID
        {
            get { return ownerID; }
            set { ownerID = value; }
        }
        public int ProgramID
        {
            get { return programID; }
            set { programID = value; }
        }
        public int DiskProgramID
        {
            get { return diskProgramID; }
            set { diskProgramID = value; }
        }
        public string DiskDescription
        {
            get { return diskDescription; }
            set { diskDescription = value; }
        }
        public string OwnerSecondName
        {
            get { return ownerSecondName; }
            set { ownerSecondName = value; }
        }
        public string OwnerFirstName
        {
            get { return ownerFirstName; }
            set { ownerFirstName = value; }
        }
        public string OwnerMiddleName
        {
            get { return ownerMiddleName; }
            set { ownerMiddleName = value; }
        }
        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }
    }
}
