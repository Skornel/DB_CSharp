using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace CD_ROM
{
    public partial class Form1 : Form
    {
        ConfigManager configManager;
        DataContext db;
        Table<Owners> owners;
        Table<Disks> disks;
        Table<Programs> programs;
        Table<DiskProgram> diskProgram;
        List<SearchResult> searchResults;
        SearchResultDrawer srDrawer;
        public Form1()
        {
            InitializeComponent();
            configManager = new ConfigManager("config.txt");
            connectionStringTextBox.Text = configManager.ReadContentFromConfigFile();
            db = new DataContext(connectionStringTextBox.Text);
            ToTablesFrom(db);
            ToGridsFromTables();
            srDrawer = new SearchResultDrawer(searchResultPanel);
        }

        private void ToTablesFrom(DataContext dataContext)
        {
            owners = db.GetTable<Owners>();
            disks = db.GetTable<Disks>();
            programs = db.GetTable<Programs>();
            diskProgram = db.GetTable<DiskProgram>();
        }
        private void ToGridsFromTables()
        {
            ownersBindingSource.DataSource = owners;
            programsBindingSource.DataSource = programs;
            disksBindingSource.DataSource = disks;
            diskProgramBindingSource.DataSource = diskProgram;
        }

        private void SaveConnectionStringToConfigButton_Click(object sender, EventArgs e)
        {
            configManager.WriteContentToConfigFile(connectionStringTextBox.Text);
        }

        private void ReadConnectionStringFromConfigButton_Click(object sender, EventArgs e)
        {
            connectionStringTextBox.Text = configManager.ReadContentFromConfigFile();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();
                db = new DataContext(connectionStringTextBox.Text);
                ToTablesFrom(db);
                ToGridsFromTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db = new DataContext(connectionStringTextBox.Text);
                ToTablesFrom(db);
                ToGridsFromTables();
            }
        }

        private void CancelChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                db = new DataContext(connectionStringTextBox.Text);
                ToTablesFrom(db);
                ToGridsFromTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string ownerId = ownerIdTextBox.Text.Trim().ToLower(),
                ownerSecondName = ownerSecondNameTextBox.Text.Trim().ToLower(),
                ownerFirstName = ownerFirstNameTextBox.Text.Trim().ToLower(),
                ownerMiddleName = ownerMiddleNameTextBox.Text.Trim().ToLower(),
                diskId = diskIdTextBox.Text.Trim().ToLower(),
                diskDescription = diskDescriptionTextBox.Text.Trim().ToLower(),
                programId = programIdTextBox.Text.Trim().ToLower(),
                programName = programNameTextBox.Text.Trim().ToLower(),
                diskProgramId = diskProgramIdTextBox.Text.Trim().ToLower(),
                diskProgramDiskId = diskProgramDiskIdTextBox.Text.Trim().ToLower(),
                diskProgramProgramId = diskProgramProgramIdTextBox.Text.Trim().ToLower();

            var q = (from d in disks
                     join dp in diskProgram on d.ID equals dp.Disk
                     join p in programs on dp.Program equals p.ID
                     join o in owners on d.Owner equals o.ID
                     select new
                     {
                         DiskID = d.ID,
                         DiskDescription = d.Description.Trim(' '),
                         OwnerID = o.ID,
                         OwnerSecondName = o.SecondName.Trim(' '),
                         OwnerFirstName = o.FirstName.Trim(' '),
                         OwnerMiddleName = o.MiddleName.Trim(' '),
                         DiskProgramID = dp.ID,
                         ProgramID = p.ID,
                         ProgramName = p.Name.Trim(' ')
                     }).ToList();
            try
            {
                if (ownerId != "")
                    q = q.Where(elem => elem.OwnerID == Convert.ToInt32(ownerId)).ToList();
                if (ownerSecondName != "")
                    q = q.Where(elem => elem.OwnerSecondName.ToLower().Contains(ownerSecondName)).ToList();
                if (ownerFirstName != "")
                    q = q.Where(elem => elem.OwnerFirstName.ToLower().Contains(ownerFirstName)).ToList();
                if (ownerMiddleName != "")
                    q = q.Where(elem => elem.OwnerMiddleName.ToLower().Contains(ownerMiddleName)).ToList();
                if (diskId != "")
                    q = q.Where(elem => elem.DiskID == Convert.ToInt32(diskId)).ToList();
                if (diskDescription != "")
                    q = q.Where(elem => elem.DiskDescription.ToLower().Contains(diskDescription)).ToList();
                if (programId != "")
                    q = q.Where(elem => elem.ProgramID == Convert.ToInt32(programId)).ToList();
                if (programName != "")
                    q = q.Where(elem => elem.ProgramName.ToLower().Contains(programName)).ToList();
                if (diskProgramId != "")
                    q = q.Where(elem => elem.DiskProgramID == Convert.ToInt32(diskProgramId)).ToList();
                if (diskProgramDiskId != "")
                    q = q.Where(elem => elem.DiskID == Convert.ToInt32(diskProgramDiskId)).ToList();
                if (diskProgramProgramId != "")
                    q = q.Where(elem => elem.ProgramID == Convert.ToInt32(diskProgramProgramId)).ToList();

                q = (from elem in q
                     orderby elem.DiskID, elem.OwnerID, elem.ProgramID
                     select elem).ToList();

                searchResults = new List<SearchResult>();
                foreach (var elem in q)
                {
                    searchResults.Add(new SearchResult
                    {
                        DiskID = elem.DiskID,
                        DiskDescription = elem.DiskDescription,
                        OwnerID = elem.OwnerID,
                        OwnerSecondName = elem.OwnerSecondName,
                        OwnerFirstName = elem.OwnerFirstName,
                        OwnerMiddleName = elem.OwnerMiddleName,
                        DiskProgramID = elem.DiskProgramID,
                        ProgramID = elem.ProgramID,
                        ProgramName = elem.ProgramName
                    });
                }
                srDrawer.DrawSearchResult(searchResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
